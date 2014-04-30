#region References
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using OpenGlExtensions.Classes;
using OpenGlExtensions.Interfaces;
using Tao.OpenGl;
using Tao.Platform.Windows; 
#endregion

namespace OpenGlExtensions
{
    public abstract class OpenGlControlBase : UserControl, IOpenGlContext, IOpenGlContextInternal
    {
        #region Private Fields

        private int fontHandle = 0;
        private IntPtr deviceContext = IntPtr.Zero;                         // GDI device context
        private IntPtr renderingContext = IntPtr.Zero;                      // Rendering context
        private IntPtr windowHandle = IntPtr.Zero;                          // Holds our window handle
        private bool autoCheckErrors = false;                               // Should we provide glGetError()?
        private bool autoFinish = false;                                    // Should we provide a glFinish()?
        private bool autoMakeCurrent = true;                                // Should we automatically make the rendering context current?
        private bool autoSwapBuffers = true;                                // Should we automatically swap buffers?
        private byte accumBits = 0;                                         // Accumulation buffer bits
        private byte colorBits = 32;                                        // Color buffer bits
        private byte depthBits = 16;                                        // Depth buffer bits
        private byte stencilBits = 0;                                       // Stencil buffer bits
        private int errorCode = Gl.GL_NO_ERROR;                             // The GL error code
        #endregion Private Fields

        #region Public Properties
        public IDrawingArea DrawingArea { get; set; }

        #region AccumBits
        /// <summary>
        ///     Gets and sets the OpenGL control's accumulation buffer depth.
        /// </summary>
        [Category("OpenGL Properties"), Description("Accumulation buffer depth in bits.")]
        public byte AccumBits {
            get {
                return accumBits;
            }
            set {
                accumBits = value;
            }
        }
        #endregion AccumBits

        #region ColorBits
        /// <summary>
        ///     Gets and sets the OpenGL control's color buffer depth.
        /// </summary>
        [Category("OpenGL Properties"), Description("Color buffer depth in bits.")]
        public byte ColorBits {
            get {
                return colorBits;
            }
            set {
                colorBits = value;
            }
        }
        #endregion ColorBits

        #region DepthBits
        /// <summary>
        ///     Gets and sets the OpenGL control's depth buffer (Z-buffer) depth.
        /// </summary>
        [Category("OpenGL Properties"), Description("Depth buffer (Z-buffer) depth in bits.")]
        public byte DepthBits {
            get {
                return depthBits;
            }
            set {
                depthBits = value;
            }
        }
        #endregion DepthBits

        #region StencilBits
        /// <summary>
        ///     Gets and sets the OpenGL control's stencil buffer depth.
        /// </summary>
        [Category("OpenGL Properties"), Description("Stencil buffer depth in bits.")]
        public byte StencilBits {
            get {
                return stencilBits;
            }
            set {
                stencilBits = value;
            }
        }
        #endregion StencilBits

        #region AutoCheckErrors
        /// <summary>
        ///     Gets and sets the OpenGL control's automatic sending of a glGetError command
        ///     after drawing.
        /// </summary>
        [Category("OpenGL Properties"), Description("Automatically send a glGetError command after drawing?")]
        public bool AutoCheckErrors {
            get {
                return autoCheckErrors;
            }
            set {
                autoCheckErrors = value;
            }
        }
        #endregion AutoCheckErrors

        #region AutoFinish
        /// <summary>
        ///     Gets and sets the OpenGL control's automatic sending of a glFinish command
        ///     after drawing.
        /// </summary>
        [Category("OpenGL Properties"), Description("Automatically send a glFinish command after drawing?")]
        public bool AutoFinish {
            get {
                return autoFinish;
            }
            set {
                autoFinish = value;
            }
        }
        #endregion AutoFinish

        #region AutoMakeCurrent
        /// <summary>
        ///     Gets and sets the OpenGL control's automatic forcing of the rendering context to
        ///     be current before drawing.
        /// </summary>
        [Category("OpenGL Properties"), Description("Automatically make the rendering context current before drawing?")]
        public bool AutoMakeCurrent {
            get {
                return autoMakeCurrent;
            }
            set {
                autoMakeCurrent = value;
            }
        }
        #endregion AutoMakeCurrent

        #region AutoSwapBuffers
        /// <summary>
        ///     Gets and sets the OpenGL control's automatic sending of a SwapBuffers command
        ///     after drawing.
        /// </summary>
        [Category("OpenGL Properties"), Description("Automatically send a SwapBuffers command after drawing?")]
        public bool AutoSwapBuffers {
            get {
                return autoSwapBuffers;
            }
            set {
                autoSwapBuffers = value;
            }
        }
        #endregion AutoSwapBuffers
        #endregion Public Properties

        #region Protected Property Overloads
        #region CreateParams CreateParams
        /// <summary>
        ///     Overrides the control's class style parameters.
        /// </summary>
        protected override CreateParams CreateParams { 
            get {
                Int32 CS_VREDRAW = 0x1;
                Int32 CS_HREDRAW = 0x2;
                Int32 CS_OWNDC = 0x20;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = cp.ClassStyle | CS_VREDRAW | CS_HREDRAW | CS_OWNDC;
                return cp;
            }
        }
        #endregion CreateParams CreateParams
        #endregion Protected Property Overloads

        #region SimpleOpenGlControl()
        /// <summary>
        ///     Constructor.  Creates contexts and sets properties.
        /// </summary>
        public OpenGlControlBase()
        {
            InitializeStyles();
        }
        #endregion SimpleOpenGlControl()

        #region Dispose(bool disposing)
        /// <summary>
        ///     Disposes the control.
        /// </summary>
        /// <param name="disposing">Was the disposed manually called?</param>
        protected override void Dispose(bool disposing) { 
            DestroyContexts();
            base.Dispose(disposing);
        }
        #endregion Dispose(bool disposing) 

        #region InitializeStyles()
        /// <summary>
        ///     Initializes the control's styles.
        /// </summary>
        private void InitializeStyles() {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, false);
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
        }
        #endregion InitializeStyles()

        #region DestroyContexts()
		/// <summary>
		/// 
		/// </summary>
        public void DestroyContexts() {
            if(renderingContext != IntPtr.Zero) {
                Wgl.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
                Wgl.wglDeleteContext(renderingContext);
                renderingContext = IntPtr.Zero;
            }
            if(deviceContext != IntPtr.Zero) {
                if(windowHandle != IntPtr.Zero) {
                    User.ReleaseDC(windowHandle, deviceContext);
                }
                deviceContext = IntPtr.Zero;
            }
            if (fontHandle != 0)
            {
                Gl.glDeleteLists(fontHandle, 256);
            }
        }
        #endregion DestroyContexts()

        #region InitializeContexts()
        
        private void CreateFont3D()
        {
            Gdi.SelectObject(deviceContext, Font.ToHfont());
            fontHandle = Gl.glGenLists(256);
            Wgl.wglUseFontBitmapsA(deviceContext, 0, 256, fontHandle);
        }

        /// <summary>
        ///     Creates the OpenGL contexts.
        /// </summary>
        public void InitializeContexts() {
            int pixelFormat;                                                // Holds the selected pixel format

            windowHandle = this.Handle;                                     // Get window handle

            if(windowHandle == IntPtr.Zero) {                               // No window handle means something is wrong
                throw new Exception("Window creation error.  No window handle.");
            }

            Gdi.PIXELFORMATDESCRIPTOR pfd = new Gdi.PIXELFORMATDESCRIPTOR();// The pixel format descriptor
            pfd.nSize = (short) Marshal.SizeOf(pfd);                        // Size of the pixel format descriptor
            pfd.nVersion = 1;                                               // Version number (always 1)
            pfd.dwFlags = Gdi.PFD_DRAW_TO_WINDOW |                          // Format must support windowed mode
                        Gdi.PFD_SUPPORT_OPENGL |                            // Format must support OpenGL
                        Gdi.PFD_DOUBLEBUFFER;                               // Must support double buffering
            pfd.iPixelType = (byte) Gdi.PFD_TYPE_RGBA;                      // Request an RGBA format
            pfd.cColorBits = (byte) colorBits;                              // Select our color depth
            pfd.cRedBits = 0;                                               // Individual color bits ignored
            pfd.cRedShift = 0;
            pfd.cGreenBits = 0;
            pfd.cGreenShift = 0;
            pfd.cBlueBits = 0;
            pfd.cBlueShift = 0;
            pfd.cAlphaBits = 0;                                             // No alpha buffer
            pfd.cAlphaShift = 0;                                            // Alpha shift bit ignored
            pfd.cAccumBits = accumBits;                                     // Accumulation buffer
            pfd.cAccumRedBits = 0;                                          // Individual accumulation bits ignored
            pfd.cAccumGreenBits = 0;
            pfd.cAccumBlueBits = 0;
            pfd.cAccumAlphaBits = 0;
            pfd.cDepthBits = depthBits;                                     // Z-buffer (depth buffer)
            pfd.cStencilBits = stencilBits;                                 // No stencil buffer
            pfd.cAuxBuffers = 0;                                            // No auxiliary buffer
            pfd.iLayerType = (byte) Gdi.PFD_MAIN_PLANE;                     // Main drawing layer
            pfd.bReserved = 0;                                              // Reserved
            pfd.dwLayerMask = 0;                                            // Layer masks ignored
            pfd.dwVisibleMask = 0;
            pfd.dwDamageMask = 0;

            deviceContext = User.GetDC(windowHandle);                       // Attempt to get the device context
            if(deviceContext == IntPtr.Zero) {                              // Did we not get a device context?                
                throw new Exception("Can not create a GL device context.");
            }

            pixelFormat = Gdi.ChoosePixelFormat(deviceContext, ref pfd);    // Attempt to find an appropriate pixel format
            if(pixelFormat == 0) {          
                throw new Exception("Can not find a suitable PixelFormat.");                                // Did windows not find a matching pixel format?
            }

            if(!Gdi.SetPixelFormat(deviceContext, pixelFormat, ref pfd)) {  // Are we not able to set the pixel format?
                throw new Exception("Can not set the chosen PixelFormat.  Chosen PixelFormat was " + pixelFormat + ".");
            }

            renderingContext = Wgl.wglCreateContext(deviceContext);         // Attempt to get the rendering context
            if(renderingContext == IntPtr.Zero) {                           // Are we not able to get a rendering context?
                
                throw new Exception("Can not create a GL rendering context."); 
            }

            MakeCurrent();                                                  // Attempt to activate the rendering context

            CreateFont3D();

            SetView();
        }
        #endregion InitializeContexts()

        #region MakeCurrent()
		/// <summary>
		/// 
		/// </summary>
        public void MakeCurrent() {
            // Are we not able to activate the rending context?
            //if(deviceContext == IntPtr.Zero || renderingContext == IntPtr.Zero || !Wgl.wglMakeCurrent(deviceContext, renderingContext)) {
            if(!Wgl.wglMakeCurrent(deviceContext, renderingContext)) {
                MessageBox.Show("Can not activate the GL rendering context.", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
        }
        #endregion MakeCurrent()

        #region SwapBuffers()
		/// <summary>
		/// 
		/// </summary>
        public void SwapBuffers() {
            Gdi.SwapBuffersFast(deviceContext);
        }
        #endregion SwapBuffers()

        #region OnPaint(PaintEventArgs e)
        protected override void OnResize(EventArgs e)
        {
            Gl.glViewport(0, 0, Width, Height);
        }

        protected void ClearColor()
        {
            Gl.glClearColor(BackColor.R / 256f, BackColor.G / 256f, BackColor.B / 256f, 1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
        }

        /// <summary>
        ///     Paints the control.
        /// </summary>
        /// <param name="e">The paint event arguments.</param>
        protected override void OnPaint(PaintEventArgs e) {
            if(this.DesignMode) {
                e.Graphics.Clear(this.BackColor);
                if (this.BackgroundImage != null)
                    e.Graphics.DrawImage(this.BackgroundImage, this.ClientRectangle, 0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height, GraphicsUnit.Pixel);
                e.Graphics.Flush();
                return;
            }
            
            if(deviceContext == IntPtr.Zero || renderingContext == IntPtr.Zero) {
                MessageBox.Show("No device or rendering context available!");
                return;
            }

            if(autoMakeCurrent) {
                MakeCurrent();
            }
            ClearColor();

            var drawable = DrawingArea as IDrawableInternal;
            if (drawable != null)
            {
                drawable.Draw(); 
            }           

            if(autoFinish) {
                Gl.glFinish();
            }

            if(autoCheckErrors) {
                errorCode = Gl.glGetError();
                if(errorCode != Gl.GL_NO_ERROR) {
                    switch(errorCode) {
                        case Gl.GL_INVALID_ENUM:
                            MessageBox.Show("GL_INVALID_ENUM - An unacceptable value has been specified for an enumerated argument.  The offending function has been ignored.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case Gl.GL_INVALID_VALUE:
                            MessageBox.Show("GL_INVALID_VALUE - A numeric argument is out of range.  The offending function has been ignored.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case Gl.GL_INVALID_OPERATION:
                            MessageBox.Show("GL_INVALID_OPERATION - The specified operation is not allowed in the current state.  The offending function has been ignored.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case Gl.GL_STACK_OVERFLOW:
                            MessageBox.Show("GL_STACK_OVERFLOW - This function would cause a stack overflow.  The offending function has been ignored.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case Gl.GL_STACK_UNDERFLOW:
                            MessageBox.Show("GL_STACK_UNDERFLOW - This function would cause a stack underflow.  The offending function has been ignored.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case Gl.GL_OUT_OF_MEMORY:
                            MessageBox.Show("GL_OUT_OF_MEMORY - There is not enough memory left to execute the function.  The state of OpenGL has been left undefined.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        default:
                            MessageBox.Show("Unknown GL error.  This should never happen.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                    }
                }
            }

            if(autoSwapBuffers) {
                SwapBuffers();
            }
        }
        #endregion OnPaint(PaintEventArgs e)

        #region OnPaintBackground(PaintEventArgs e)
        /// <summary>
        ///     Paints the background.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }
        #endregion OnPaintBackground(PaintEventArgs e)

        #region Set methods methods

        public void SetColor(Color color)
        {
            Gl.glColor3f(color.R / 256f, color.G / 256f, color.B / 256f);
        }

        public void DrawText(string text)
        {
            Gl.glPushAttrib(Gl.GL_LIST_BIT);
            Gl.glListBase(fontHandle);
            byte[] bText = Encoding.UTF8.GetBytes(text);
            Gl.glCallLists(text.Length, Gl.GL_UNSIGNED_BYTE, bText);
            Gl.glPopAttrib();
        }

        void IOpenGlContextInternal.BeginLines()
        {
            BeginLines();
        }

        protected abstract void SetView();

        internal void BeginLines()
        {
            Begin(Gl.GL_LINES);
        }

        public void Begin(int mode)
        {
            Gl.glBegin(Gl.GL_LINES); 
        }

        public void End()
        {
            Gl.glEnd();
        }
        #endregion

        public override void Refresh()
        {
            base.Refresh();
            Invalidate();
        }

        #region DrawText()

        void IOpenGlContextInternal.DrawText(string text)
        {
            DrawText(text);
        }
        #endregion
    }
}