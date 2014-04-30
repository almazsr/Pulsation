using System;
using System.Drawing;
using OpenGlExtensions.Interfaces;

namespace OpenGlExtensions.Classes
{
    public abstract class Shape2D : IDrawable, IDrawableInternal
    {
        protected Shape2D()
        {
            Visible = true;
        }

        #region Properties

        internal IOpenGlContext2D Context2D { get; set; }

        internal IOpenGlContext2DInternal Context2DInternal
        {
            get { return Context2D as IOpenGlContext2DInternal; }
        }

        public Color Color { get; set; }

        public bool Visible { get; set; } 
        #endregion

        protected abstract void Draw();

        void IDrawableInternal.Draw()
        {
            if (Context2DInternal == null)
            {
                throw new Exception();
            }
            if (Visible)
            {    
                Context2DInternal.SetColor(Color);
                Draw();
            }
        }
    }
}