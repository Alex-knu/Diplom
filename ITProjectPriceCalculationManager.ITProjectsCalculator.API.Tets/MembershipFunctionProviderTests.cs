using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.MembershipFunction;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Tets;

[TestFixture]
    public class MembershipFunctionProviderTests
    {
        private MembershipFunctionStrategy _provider;

        [SetUp]
        public void Setup()
        {
            _provider = new MembershipFunctionStrategy();
        }

        [Test]
        public void GetMembershipFunction_SigmoidMembershipFunction_ReturnsCorrectType()
        {
            var strategyId = new Guid("f4bf3d51-4f18-42e5-b92f-1e8cf40dca1a");
            var result = _provider.GetMembershipFunction(strategyId, 1.0, 2.0);

            Assert.IsInstanceOf<SigmoidMembershipFunction>(result);
        }

        [Test]
        public void GetMembershipFunction_GaussianMembershipFunction_ReturnsCorrectType()
        {
            var strategyId = new Guid("a13bcaf8-0d49-4df7-ba32-0d6fd5b4c4c0");
            var result = _provider.GetMembershipFunction(strategyId, 1.0, 2.0);

            Assert.IsInstanceOf<GaussianMembershipFunction>(result);
        }

        [Test]
        public void GetMembershipFunction_ExponentialMembershipFunction_ReturnsCorrectType()
        {
            var strategyId = new Guid("6d8622f5-8e17-49a9-b66e-5e11fd761278") ;
            var result = _provider.GetMembershipFunction(strategyId, 1.0, 2.0);

            Assert.IsInstanceOf<ExponentialMembershipFunction>(result);
        }

        [Test]
        public void GetMembershipFunction_QuadraticMembershipFunction_ReturnsCorrectType()
        {
            var strategyId = new Guid("9c4b86fc-0f8f-4e26-8de0-29c57b076a54");
            var result = _provider.GetMembershipFunction(strategyId, 1.0, 2.0, 3.0);

            Assert.IsInstanceOf<QuadraticMembershipFunction>(result);
        }

        [Test]
        public void GetMembershipFunction_InvalidStrategyId_ThrowsNotImplementedException()
        {
            var invalidStrategyId = Guid.NewGuid();

            Assert.Throws<NotImplementedException>(() => _provider.GetMembershipFunction(invalidStrategyId, 1.0, 2.0));
        }
    }
