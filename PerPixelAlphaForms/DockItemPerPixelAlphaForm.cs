using System;
using System.Windows.Forms;

namespace PerPixelAlphaForms
{
	public class DockItemPerPixelAlphaForm : PerPixelAlphaForm
	{
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.ExStyle = 524416;
				createParams.Style = -738197504;
				createParams.ClassStyle |= 128;
				return createParams;
			}
		}
	}
}
