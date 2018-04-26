using GeekHunter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeekHunterTest
{
    [TestClass]
    public class Validate
    {
        string withinRange1 = "Sreeman";
        string withinRange2 = "Peculiarentities";
        string outOfBounds1 = "S";
        string outOfBounds2 = "whatwillyoudowhenthegoonscomeknocking";
        string edgeCase = "S N";

        InputValidation validate = new InputValidation();

        [TestMethod]
        public void ValidateNull()
        {
            var result = validate.Validate(null, 2, 25);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void ValidateOutOfRange()
        {
            var result = validate.Validate(outOfBounds1, 2, 25);
            Assert.AreEqual(null, result);

            result = validate.Validate(outOfBounds2, 2, 25);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void ValidateWithinRange()
        {
            var result = validate.Validate(withinRange1, 2, 25);
            Assert.AreEqual(withinRange1, result);

            result = validate.Validate(withinRange2, 2, 25);
            Assert.AreEqual(withinRange2, result);
        }

        [TestMethod]
        public void ValidateEdgeCase() // 2 and 25
        {
            InputValidation validate = new InputValidation();
            var result = validate.Validate(edgeCase, 2, 25);
            Assert.AreEqual("SN", result);
        }


        [TestMethod]
        public void ValidateEmailValid()
        {
            Assert.AreEqual(true, validate.EmailValidate("jon.snow@gmail.com"));
            Assert.AreEqual(true, validate.EmailValidate("jon_snow@gmail.com"));

        }

        [TestMethod]
        public void ValidateEmailInvalid()
        {
            var result = validate.EmailValidate(null);
            Assert.AreEqual(false, validate.EmailValidate("jon..snow@gmail.com"));
            Assert.AreEqual(false, validate.EmailValidate("jon/snow@gmail.com"));
            Assert.AreEqual(false, validate.EmailValidate(null));
        }
    }
}
