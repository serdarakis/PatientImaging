using PatientImaging.FileTracker.Models;
using System;

namespace PatientImaging.FileTracker.Mappers
{
    public static class GenderMapper
    {
        public static Messages.Gender Map(GenderXmlModel gender)
        {
            switch (gender)
            {
                case GenderXmlModel.Female:
                    return Messages.Gender.Female;
                case GenderXmlModel.Male:
                    return Messages.Gender.Female;
                case GenderXmlModel.NotSpecified:
                    return Messages.Gender.NotSpecified;
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}
