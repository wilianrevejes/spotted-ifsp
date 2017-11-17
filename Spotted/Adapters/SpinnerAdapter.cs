using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using System;

namespace Spotted {

    
    public class SpinnerAdapter : BaseAdapter, ISpinnerAdapter {
        IList<SelectItem> items;
        Context context;
        int resourceId;

        public override int Count {
            get {
                return items.Count;
            }
        }
        
        public SpinnerAdapter(Context context, int resourceId, IList<SelectItem> items) : base() {
            this.items = new List<SelectItem>();
            Console.WriteLine("-------------------------");
            Console.WriteLine(items.Count);

            foreach (SelectItem item in items) {
                this.items.Add(item);
            }

            this.context = context;
            this.resourceId = resourceId;
        }

        public override Java.Lang.Object GetItem(int position) {
            return null;
        }

        public override long GetItemId(int position) {
            return (long)position;
        }

        public string GetLabel(int position) {
            SelectItem item = items[position];
            return item.Label;
        }

        public override View GetView(int position, View convertView, ViewGroup parent) {
            
            // I created a dynamic TextView here, but you can reference your own  custom layout for each spinner item
            TextView label = new TextView(context);
            label.SetTextColor(Color.Black);
            // Then you can get the current item using the values array (Users array) and the current position
            // You can NOW reference each method you has created in your bean object (User class)
            label.Text = this.GetLabel(position);
            label.TextSize = 18;
            label.SetPadding(10, 2, 30, 2);

            // And finally return your dynamic (or custom) view for each spinner item
            return label;
            
        }

        protected override void Dispose(bool disposing) {
            context = null;
            base.Dispose(disposing);
        }
    }
}