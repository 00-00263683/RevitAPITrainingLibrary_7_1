using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;

namespace RevitAPITrainingLibrary_7_1
{
    public class FamilyInstanceUtils
    {
        public static FamilyInstance CreateFamilyInstance(
            ExternalCommandData commandData,
            FamilySymbol oFamSymb,
            XYZ insertionPoint,
            Level oLevel)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.DB.Document doc = uidoc.Document;
            FamilyInstance familyInstance = null;
            //create family instance
            using (var t = new Autodesk.Revit.DB.Transaction(doc, "Create family instance"))
            {
                t.Start();
                if (!oFamSymb.IsActive)
                {
                    oFamSymb.Activate();
                    doc.Regenerate();
                }
                familyInstance = doc.Create.NewFamilyInstance(
                                    insertionPoint,
                                    oFamSymb,
                                    oLevel,
                                    Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
                t.Commit();
            }
            return familyInstance;
        }

        public static IEnumerable<FamilySymbol> GetSheetTemplate(ExternalCommandData commandData)
        {
            throw new NotImplementedException();
        }
    }
}
