using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.IO;

namespace TestAutomationCourse.Exercises.e05.JSON
{
    [TestFixture]
    internal class BeatlesJSONTests
    {
        private JToken jsonBeatles;

        [SetUp]
        public void Setup()
        {
            using (var sr = new StreamReader(".//Exercises//e05.JSON//Beatles.json"))
            {
                var reader = new JsonTextReader(sr);
                this.jsonBeatles = JObject.Load(reader);
            }
        }

        [Test]
        public void There_are_four_artists()
        {

            JObject json = (JObject)this.jsonBeatles;
            var jsonBeatles = json["Beatles"];
            JArray artists_array = (JArray)jsonBeatles["Artists"];
            int num_of_artists = artists_array.Count;
            Assert.That(num_of_artists, Is.EqualTo(4), "Number Of Artists is More Than 4");
        }

        [Test]
        public void two_are_dead_and_two_are_alive()
        {
            JObject json = (JObject)this.jsonBeatles;
            var jsonBeatles = json["Beatles"];
            JArray artists_array = (JArray)jsonBeatles["Artists"];

            int dead = 0, alive = 0;

            for (int i = 0; i < artists_array.Count; i++)
            {
                if (artists_array[i]["IsAlive"].ToString() == "Yes")
                    alive++;
                else if (artists_array[i]["IsAlive"].ToString() == "No")
                    dead++;
            }

            Assert.That(alive, Is.EqualTo(2), "Alive Are More Than 2");
            Assert.That(dead, Is.EqualTo(2), "Dead Are More Than 2");

        }

        [Test]
        public void ringo_plays_drums()
        {
            JObject json = (JObject)this.jsonBeatles;
            var jsonBeatles = json["Beatles"];
            JArray artists_array = (JArray)jsonBeatles["Artists"];

            JObject item;
            
            bool flag = false;

            for (int i = 0; i < artists_array.Count; i++)
            {
                if (artists_array[i]["Name"].ToString().Contains("Ringo"))
                {
                    if (artists_array[i]["Plays"].ToString() == "Drums")
                    {
                        flag = true;
                        break;
                    }
                }
            }

            Assert.IsTrue(flag, "'Ringo' Doesn't Play 'Drums'");
        }

    }
}
