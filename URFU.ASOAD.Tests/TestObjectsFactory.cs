using URFU.ASOAD.Core.Factories;
using URFU.ASOAD.Dto;

namespace URFU.ASOAD.Tests
{
    public static class TestObjectsFactory
    {
        public static Questionary CreateQuestionary()
        {
            Questionary questionary = new QuestionaryFactory().Create();
            DataGenerator dataGenerator = new DataGenerator { CountElementsInArray = 3};
            dataGenerator.FillObject(questionary);
            foreach (SkillTheme skillTheme in questionary.SkillThemes)
            {
                for (int index = 0; index < 3; index++)
                {
                    skillTheme.Skills.Add((Skill)dataGenerator.Generate(typeof(Skill)));
                }
            }
            return questionary;
        }
    }
}
