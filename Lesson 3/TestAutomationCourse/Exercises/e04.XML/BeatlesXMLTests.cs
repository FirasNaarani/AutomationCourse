using NUnit.Framework;
using System.Xml;

namespace TestAutomationCourse.Exercises.e04.Xml
{
    internal class BeatlesXMLTests
    {
        private XmlDocument doc;

        [SetUp]
        public void Setup()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(".//Exercises//e04.Xml//Beatles.xml");
            this.doc = doc;
        }

        [Test]
        public void There_are_four_artists()
        {
            XmlElement root_element = this.doc.DocumentElement;

            int num_of_artists = root_element.GetElementsByTagName("Artist").Count;
            Assert.That(num_of_artists, Is.EqualTo(4));
        }

        [Test]
        public void Two_are_dead_and_two_are_alive()
        {
            XmlElement root_element = this.doc.DocumentElement;

            var list_elements = root_element.GetElementsByTagName("Artist");

            int dead = 0, alive = 0;

            XmlNode _element;

            for (int i = 0; i < list_elements.Count; i++)
            {
                _element = list_elements[i];
                if (_element.ChildNodes[1].InnerText == "Yes")
                    alive++;
                else if (_element.ChildNodes[1].InnerText == "No")
                    dead++;
            }

            Assert.That(alive, Is.EqualTo(2),"Alive Are More Than 2");
            Assert.That(dead, Is.EqualTo(2), "Dead Are More Than 2");

        }

        [Test]
        public void Ringo_plays_drums()
        {
            XmlElement root_element = this.doc.DocumentElement;

            XmlNode _element = root_element.GetElementsByTagName("Artist").Item(3);

            Assert.AreEqual(_element.ChildNodes[0].InnerText, "Drums", "Ringo doesn't play Drums");

        }

    }
}
