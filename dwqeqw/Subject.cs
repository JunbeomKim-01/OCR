using System;
using System.Collections.Generic;
using System.Text;

namespace dwqeqw
{
    public interface Subject
    {
        void registerObserver(Opserver opserver);
        void removeObserver(Opserver opserver);
        void notifyObservers();
    }
}
