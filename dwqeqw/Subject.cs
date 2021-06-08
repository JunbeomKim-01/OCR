using System;
using System.Collections.Generic;
using System.Text;

namespace dwqeqw
{
    public interface Subject
    {
        void registerObserver(Observer observer);
        void removeObserver(Observer observer);
        void notifyObservers();
    }
}
