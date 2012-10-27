using System;

using NUnit.Framework;

using URFU.ASOAD.Dto;
using URFU.ASOAD.Dto.Resolvers;

namespace URFU.ASOAD.Tests.Dto.Resolvers
{
    [TestFixture]
    public class SkillAreaResolverTest
    {
        [Test]
        public void TestAllAreasHasTitle()
        {
            int index = -1;
            while (Enum.IsDefined(typeof(SkillArea), ++index))
            {
                Assert.IsNotEmpty(SkillAreaResolver.SkillThemeTitles[(SkillArea)index]);
            }
        }
    }
}
