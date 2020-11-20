using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Security.Claims;

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKEntity
    {
        public XRSKFocUsuarios Usuario;

        public XRSKEntity()
        {
            Usuario = new XRSKFocUsuarios();
        }// Constructor por defecto

        public XRSKEntity(ClaimsPrincipal _Usuario)
        {
            string username = _Usuario.Claims.Where(x => x.Type == "username").FirstOrDefault().Value;
            Usuario = new XRSKFocUsuarios(username);
        }// Constructor por defecto

        public static TEntity GetOriginal<TEntity>(XRSKDataContext db, TEntity updatedEntity) where TEntity : class
        {
            Func<PropertyValues, Type, object> getOriginal = null;
            getOriginal = (originalValues, type) =>
            {
                object original = Activator.CreateInstance(type, true);

                foreach (var property in originalValues.Properties)
                //foreach (var ptyName in originalValues.PropertyNames)
                {
                    //var property = type.GetProperty(ptyName);
                    //object value = originalValues[ptyName];
                    object value = originalValues[property];
                    if (value is PropertyValues) //nested complex object
                    {
                        property.PropertyInfo.SetValue(original, getOriginal(value as PropertyValues, property.ClrType));
                    }
                    else
                    {
                        property.PropertyInfo.SetValue(original, value);
                    }
                }
                return original;
            };
            return (TEntity)getOriginal(db.Entry(updatedEntity).OriginalValues, typeof(TEntity));
        }// end GetOriginal common method
    }
}