using System;
using System.Collections.Generic;

using URFU.ASOAD.Dto;
using URFU.ASOAD.Dto.Resolvers;

namespace URFU.ASOAD.Core.Factories
{
    /// <summary>
    /// Фабрика создания объектов анкеты
    /// </summary>
    public class QuestionaryFactory
    {
        public Questionary Create()
        {
            return new Questionary { Person = CreatePerson(), SkillThemes = CreateSkillThemes() };
        }

        private List<SkillTheme> CreateSkillThemes()
        {
            List<SkillTheme> skillThemes = new List<SkillTheme>();
            int themeIndex = -1;
            while (Enum.IsDefined(typeof(SkillArea), ++themeIndex))
            {
                SkillArea skillArea = (SkillArea)themeIndex;
                skillThemes.Add(new SkillTheme { Area = skillArea, Title = SkillAreaResolver.SkillThemeTitles[skillArea], Skills = CreateSkills(skillArea) });
            }
            return skillThemes;
        }

        private Person CreatePerson()
        {
            return new Person {FullName = new FullName(), Birthday = DateTime.Now, Contact = new Contact(), Education = new Education()};
        }

        private List<Skill> CreateSkills(SkillArea skillArea)
        {
            List<Skill> skills = new List<Skill>();
            return skills;
        }
    }
}
