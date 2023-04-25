namespace CSharpBoosts
{
    public class Locker
    {
        private bool _locked;

        public bool Lock()
        {
            if (_locked) return false;
            _locked = true;
            return true;
        }

        public void Unlock()
        {
            _locked = false;
        }
    }
}