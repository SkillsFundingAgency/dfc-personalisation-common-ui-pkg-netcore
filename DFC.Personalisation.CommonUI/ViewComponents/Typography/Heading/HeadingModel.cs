﻿namespace DFC.Personalisation.CommonUI.ViewComponents.Typography.Heading
{
    public class HeadingModel : ViewModelBase, IHeadingAttributes
    {
        public string Text { get; set; }
        public string Caption { get; set; }
        public string Tag { get; set; }
        public string Size { get; set; }
        public string AdditionalClass { get; set; }
    }
}
