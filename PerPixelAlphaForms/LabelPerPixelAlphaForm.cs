using System;
using System.Windows.Forms;

namespace PerPixelAlphaForms
{
	public class LabelPerPixelAlphaForm : PerPixelAlphaForm
	{
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.ExStyle = 134742176;
				createParams.Style = -738197504;
				createParams.ClassStyle |= 128;
				return createParams;
			}
		}
	}
}
