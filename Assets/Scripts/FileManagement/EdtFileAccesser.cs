using UnityEngine;
using UnityEngine.UI;
using RadiacUI;
using StateOfWarUtility;
using System.IO;

namespace MapEditor
{
    public sealed class EdtFileAccesser : FileAccesser
    {
        protected override string textRequest => "EdtFileName";
        protected override string notFound => "$EdtNotFound$";
        protected override string readHint => "$EdtReadHint$";
        
        protected override bool LoadNewFile(string path)
        {
            if(!Edt.Validate(path)) return false;
            
            Global.inst.edt = new Edt(path);
            Global.inst.edtName = path;
            Global.inst.textAgent.Update(textRequest, Path.GetFileName(path));
            
            Global.inst.selection.Reset();
            
            return true;
        }
    }
}
