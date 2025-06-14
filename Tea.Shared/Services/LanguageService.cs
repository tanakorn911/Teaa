using Tea.Shared.Models;

namespace Tea.Shared.Services
{
    public class LanguageService
    {
        private Language _currentLanguage = Language.Thai;
        public event Action? LanguageChanged;

        public Language CurrentLanguage => _currentLanguage;

        public void SetLanguage(Language language)
        {
            if (_currentLanguage != language)
            {
                _currentLanguage = language;
                LanguageChanged?.Invoke();
            }
        }

        public void ToggleLanguage()
        {
            SetLanguage(_currentLanguage == Language.Thai ? Language.English : Language.Thai);
        }

        public string GetText(string thai, string english)
        {
            return _currentLanguage == Language.Thai ? thai : english;
        }
    }
}