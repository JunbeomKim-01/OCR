using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace dwqeqw
{
    public class Concretesubject : Subject
    {
        IList _observers = new ArrayList();
        int _value;
        public void notifyObservers()
        {
            foreach (Opserver opserver in _observers)
                opserver.update(_value);
        }

        public void registerObserver(Opserver opserver)
        {
            _observers.Add(opserver);
        }

        public void removeObserver(Opserver opserver)
        {
            _observers.Remove(opserver);
        }
        public void setValue(int val)
        {
            _value = val;
            notifyObservers();
        }

       
    }
}
