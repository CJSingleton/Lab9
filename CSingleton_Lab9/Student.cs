using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSingleton_Lab9
{
    class Student
    {
        private string firstName;
        private string lastName;
        private string hometown;
        private string favFood;
        private string favColor;

        public string FirstName
        {
            set { firstName = value; }
            get { return firstName; }
        }
        public string LastName
        {
            set { lastName = value; }
            get { return lastName; }
        }
        public string Hometown
        {
            set { hometown = value; }
            get { return hometown; }
        }
        public string FavoriteFood
        {
            set { favFood = value; }
            get { return favFood; }
        }
        public string FavoriteColor
        {
            set { favColor = value; }
            get { return favColor; }
        }
    }
}
