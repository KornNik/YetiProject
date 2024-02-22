using System;
using System.Collections.Generic;

namespace Helpers.Observer
{
	struct Observable<T>
	{
		public Action OnValueChanged;
		public Action<T> OnValueChangedTo;
		public Action<T, T> OnValueChangedFromTo;

		private T _value;

		public T Value
		{
			get { return _value; }
			set
			{
				if (!EqualityComparer<T>.Default.Equals(value, _value))
				{
					var prev = _value;
					_value = value;
					OnValueChanged?.Invoke();
					OnValueChangedTo?.Invoke(_value);
					OnValueChangedFromTo?.Invoke(prev, _value);
				}
			}
		}
	}
}
