namespace AC.Model.Utilities
{
    internal interface IPersistable
    {
        public Task SaveStateAsync(string directoryPath, string fileName);
        public Task LoadStateAsync(string directoryPath, string fileName);
    }
}
