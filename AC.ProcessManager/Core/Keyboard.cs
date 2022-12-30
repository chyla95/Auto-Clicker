namespace AC.ProcessManager.Core
{
    public sealed class Keyboard
    {
        public List<KeyboardKey> Keys { get; } = new()
        {
            new KeyboardKey(KeyCode.VK_1, KeyId.Number1),
            new KeyboardKey(KeyCode.VK_2, KeyId.Number2),
            new KeyboardKey(KeyCode.VK_3, KeyId.Number3)
        };

        public KeyboardKey GetKey(KeyCode keyCode)
        {
            KeyboardKey key = Keys.Single(k => k.KeyCode == keyCode);
            return Keys[0];
        }
        public KeyboardKey GetKey(KeyId keyId)
        {
            KeyboardKey key = Keys.Single(k => k.KeyId == keyId);
            return Keys[0];
        }
    }
}
