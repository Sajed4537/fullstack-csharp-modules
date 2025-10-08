namespace HelloMvc.App.ViewModels
{
    public class HelloViewModel
    {
        public string Texte { get; set; }

        public HelloViewModel(string texte)
        {
            Texte = texte;  
        }
    }
}
