using System;
using System.Collections.Generic;
using System.Text;

namespace APKQuickInstall.Localization
{
    public class ControlPositionManager
    {
        private Dictionary<string, Point> originalPositions = new Dictionary<string, Point>();
        private Dictionary<string, Size> originalSizes = new Dictionary<string, Size>();

        public void SaveOriginalPositions(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                string key = control.Name ?? control.GetType().Name + Guid.NewGuid().ToString();
                originalPositions[key] = control.Location;
                originalSizes[key] = control.Size;

                if (control.HasChildren)
                {
                    SaveOriginalPositions(control);
                }
            }
        }

        public void MirrorPositions(Control parent, bool isRTL)
        {
            if (!isRTL) return;

            foreach (Control control in parent.Controls)
            {
                // Calculer la nouvelle position mirrorée
                int newX = parent.ClientSize.Width - control.Right;
                control.Location = new Point(newX, control.Location.Y);

                // Appliquer aux contrôles enfants
                if (control.HasChildren)
                {
                    MirrorPositions(control, isRTL);
                }
            }
        }

        public void RestoreOriginalPositions(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                string key = control.Name ?? control.GetType().Name + Guid.NewGuid().ToString();
                if (originalPositions.ContainsKey(key))
                {
                    control.Location = originalPositions[key];
                }
                if (originalSizes.ContainsKey(key))
                {
                    control.Size = originalSizes[key];
                }
                if (control.HasChildren)
                {
                    RestoreOriginalPositions(control);
                }
            }
        }
    }
}
