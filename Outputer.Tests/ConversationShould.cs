namespace Outputer.Tests
{
    public class ConversationShould
    {
        [Fact]
        public void CreateConversation()
        {
            var conversation = new Conversation();
            conversation.Add("Someone", "A message.");

            Assert.Equal("Someone: - A message.\r\n", conversation.ToString());
        }
    }
}
