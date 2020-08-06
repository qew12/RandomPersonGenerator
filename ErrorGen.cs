using System;
using System.Text;
using Bogus;

namespace Task3
{
    public  class ErrorGen
    {
        private StringBuilder m_str;
        public ErrorGen(StringBuilder str, string locale){
           m_str = str; 
           Locale = locale;
        }
        private string Locale{ get; set; }
        private static readonly string en = "0123456789AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";
        private static readonly string ru = "0123456789АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдежзийклмнопрстуфхцчшщъыьэюя";
        private static readonly string by = "0123456789АБВГДЕЖЗIЙКЛМНОПРСТУЎФХЦЧШЫЬЭЮЯабвгдежзiйклмнопрстуўфхцчшщыьэюя";
        public double quantError ;
        private int count;
        private char RandChar()
        {
            if(Locale == "en") return en[new Randomizer().Number(en.Length-1)];
            else if(Locale == "ru") return ru[new Randomizer().Number(ru.Length-1)];
            else return by[new Randomizer().Number(by.Length-1)];

        }
        private void RandAddChar()
        {
            var ind = new Randomizer().Number(m_str.Length);
            m_str.Insert(ind, RandChar());
        }
        private void RandRemoveChar()
        {
            if(m_str.Length < 1) return;
            var ind = new Randomizer().Number(m_str.Length-1);
            m_str.Remove(ind, 1);
        }
        private void RandMoveChar()
        {
            if(m_str.Length < 2) return;
            int i = new Randomizer().Number(m_str.Length-1), j=i-1;
            if(i == 0) j = i + 1;
            char tmp = m_str[i];
            m_str[i] = m_str[j];
            m_str[j] = tmp;
        }
        private void SetRandError()
        {
            var numb = new Randomizer().Number(2);
            switch (numb)
            {
                case 0:
                RandAddChar();
                break;
                case 1:
                RandRemoveChar();
                break;
                case 2:
                RandMoveChar();
                break;
                default:
                return;
            }
        }

        public void RandError (double quantError)
        {
            count = (int) quantError;
            double randDouble = new Randomizer().Double();
            if(randDouble  <= quantError - count) count++;  
            for(int i = 0; i < count; i++)
            {
                SetRandError();
            }
        }
    }
}