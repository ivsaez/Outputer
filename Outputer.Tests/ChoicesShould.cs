using Outputer.Choicing;

namespace Outputer.Tests
{
    public class ChoicesShould
    {
        Choices choices;

        public ChoicesShould()
        {
            choices = new Choices();
        }

        [Fact]
        public void ReturnEmptyOption()
        {
            var option = choices.Select(new Input(3));

            Assert.True(option.IsEmpty);

            choices.Add("option", () => 0);

            option = choices.Select(new Input(3));

            Assert.True(option.IsEmpty);
        }

        [Fact]
        public void SelectRightOption()
        {
            choices.Add("option_1", () => 0);
            choices.Add("option_2", () => 0);

            var option = choices.Select(new Input(2));

            Assert.False(option.IsEmpty);
            Assert.Equal("option_2", option.Value);
        }

        [Fact]
        public void ApplyPriorities()
        {
            choices.Add("option_1", () => 0, 1);
            choices.Add("option_2", () => 0, 2);

            var option = choices.Select(new Input(1));

            Assert.False(option.IsEmpty);
            Assert.Equal("option_2", option.Value);

            choices.Add("option_3", () => 0, 3);

            option = choices.Select(new Input(1));

            Assert.Equal("option_3", option.Value);
        }
    }
}