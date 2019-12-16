namespace DFC.Personalisation.CommonUI.Interfaces
{
    public interface ILink
    {
        string LinkHref { get; set; }
        string LinkText { get; set; }
        string LinkTitle { get; set; }
        int LinkTabIndex { get; set; }
    }
}
