using System;
using System.Collections.Generic;
using System.Linq;

using URFU.ASOAD.Dto;
using URFU.ASOAD.Dto.Resolvers;

namespace URFU.ASOAD.Core.Factories
{
    /// <summary>
    /// Фабрика создания объектов анкеты. Статическая, так как форма анкеты одинакова.
    /// </summary>
    public static class QuestionaryFactory
    {
        private static readonly string[] LANGUAGES = new[] { "C#", "Java", "C/C++", "Pascal", "Javascript", "SQL" };

        private const string FRAMEWORK = ".Net Framework";
        private static readonly string[] FRAMEWORK_SKILLS = new[] { "WCF", "WPF/Silverlight/WinForms", "ASP.Net (MVC)" };

        private const string JAVA = "Java (JVM)";
        private static readonly string[] JAVA_SKILLS = new[] { "J2EE", "JSP/JSF", "JavaFX/GWT/ZK" };

        private const string WEB = "Web";
        private static readonly string[] WEB_SKILLS = new[] { "HTML/DHTML/HTML5", "Ajax", "CSS", "jQuery/Node.js/ExtJS/etc." };

        private const string DATABASE_FRAMEWORK = "Database Framework";
        private static readonly string[] DATABASE_FRAMEWORK_SKILLS = new[] { "ADO.Net (Entity Framework)", "LINQ to SQL", "JDO/JPA", "Hibernate/nHibernate" };

        private const string IOC = "IoC-containers";
        private static readonly string[] IOC_SKILLS = new[] { "Unity/Ninject/StructureMap", "Spring/Spring.Net", "Guice/Pico/Plexus", "XML/XSLT" };

        private static readonly string[] OTHER_SKILLS = new[] { "XML/XSLT", "UML", "Multithreading" };

        private static readonly string[] DATABASE = new[] { "MS SQL Server", "Oracle", "MySQL/PostgreSQL/Firebird/SQLite", "NoSql databases (Trinity, MongoDB, etc.)" };

        private static readonly string[] OS = new[] { "Windows", "UNIX/Linux", "MacOS/iOS/Android" };

        private static readonly string[] METHODOLOGIES = new[] { "TDD", "Refactoring", "DDD/FDD", "XP/Scrum/Kanban", "Gang Of Four patterns", "EA-patterns", "SOA/SCA", "SOLID principles" };

        /// <summary>
        /// Создать объект анкеты с предопределёнными вопросами
        /// </summary>
        /// <returns>анкета</returns>
        public static Questionary Create()
        {
            return new Questionary { Person = CreatePerson(), SkillThemes = CreateSkillThemes() };
        }

        private static List<SkillTheme> CreateSkillThemes()
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

        private static Person CreatePerson()
        {
            return new Person { Birthday = DateTime.Now, Contact = new Contact(), Education = new Education() };
        }

        private static List<Skill> CreateSkills(SkillArea skillArea)
        {
            return createPredefinedSkills[skillArea]();
        }

        private static readonly Dictionary<SkillArea, Func<List<Skill>>> createPredefinedSkills = new Dictionary<SkillArea, Func<List<Skill>>>
        {
            { SkillArea.Languages, () => CreateSkills(LANGUAGES) },
            { SkillArea.Platforms, CreatePlatformSkills },
            { SkillArea.OperationSystems, () => CreateSkills(OS) },
            { SkillArea.Databases, () => CreateSkills(DATABASE) },
            { SkillArea.Methodologies, () => CreateSkills(METHODOLOGIES) }
        };

        private static List<Skill> CreateSkills(IEnumerable<string> names, string group = null)
        {
            return names.Select(name => CreateSkill(name, @group)).ToList();
        }

        private static Skill CreateSkill(string name, string group = null)
        {
            return new Skill { Name = name, Group = group };
        }

        private static List<Skill> CreatePlatformSkills()
        {
            List<Skill> skills = new List<Skill>();
            skills.AddRange(CreateSkills(FRAMEWORK_SKILLS, FRAMEWORK));
            skills.AddRange(CreateSkills(JAVA_SKILLS, JAVA));
            skills.AddRange(CreateSkills(WEB_SKILLS, WEB));
            skills.AddRange(CreateSkills(DATABASE_FRAMEWORK_SKILLS, DATABASE_FRAMEWORK));
            skills.AddRange(CreateSkills(IOC_SKILLS, IOC));
            skills.AddRange(CreateSkills(OTHER_SKILLS));
            return skills;
        }
    }
}
