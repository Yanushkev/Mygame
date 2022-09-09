namespace Mygame.Models
{
    public class language
    {
        public string Settings { get; }
        public string Privacy { get; }
        public string Play { get; }
        public string Garage { get; }

        public string Chousemap { get; }
        public string Chousecar { get; }
        public string Chouselanguage { get; }
        public string ConfigBack { get; }
        public string Welcome { get; }
        public string Yourmap { get; }
        public string Yourcar { get; }


        public language(string choose)
        {

            if (choose == "UA")
            {
                Garage = " Гараж ";
                Settings = "Налаштування";
                Privacy = "Контакти";
                Play = "Натисніть щоб грати";

                Chousecar =  "Оберіть авто";
                Chouselanguage = "Оберіть мову";
                ConfigBack = "Головне меню";
                Chousemap = " Оберіть карту ";
                Welcome = "Вітаю в грі";
                Yourcar = "Обране авто  ";
                Yourmap = "Обрана карта ";
            }
            else if (choose == "EN")
            {
                Garage = "Garage ";
                Settings = "Settings";
                Privacy = "Contacts";
                Play = "Tap to play";

                Chousecar = "Chouse car";
                Chouselanguage = "Chouse language";
                ConfigBack = "Main Menu";
                Chousemap = " Choose the map ";
                Welcome = "Welcome ";
                Yourcar = "Your car ";
                Yourmap = "Your map ";
            }
        }
    }
}
