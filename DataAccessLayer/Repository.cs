using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPI.DataAccessLayer
{
    public class Repository<TEntity> where TEntity : IIdentifiedEntity
    {
        //use static to hold data in memory
        private static List<TEntity> _items = new List<TEntity>();

        public Repository(List<TEntity> items)
        {
            _items = items;
        }

        /// <summary>
        /// generic Add method for Entities
        /// </summary>
        /// <param name="newItem">item been inserted</param>
        /// <returns>Id of inserted item</returns>
        public int AddItem(TEntity newItem)
        {
            int maxId = 0;
            if (_items.Count > 0) { 
                maxId = _items.Max(i => i.Id);
            }
            //assign newItem as maximum id + 1 to mimi an identity column in the database
            newItem.Id = maxId + 1;
            _items.Add(newItem);
            return newItem.Id;
        }

        /// <summary>
        /// generic Update method for Entities
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedItem"></param>
        public void UpdateItem(int id, TEntity updatedItem)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// generic Delete method for Entities
        /// </summary>
        /// <param name="id"></param>
        public void DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// generic bulk Update method for Entities
        /// </summary>
        /// <param name="updatedItems"></param>
        public void UpdateItems(List<TEntity> updatedItems)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// generic Get method for Entities
        /// </summary>
        /// <returns></returns>
        public List<TEntity> GetAllItems()
        {
            return _items;
        }

        /// <summary>
        /// generic Get Item by ID method for Entities
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity GetItemById(int id)
        {
            return _items.FirstOrDefault(p => p.Id == id);
        }

    }
}
