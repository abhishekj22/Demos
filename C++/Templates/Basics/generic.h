#ifndef GENERIC_H
#define GENERIC_H

namespace Generic
{
	template<typename E>
	struct StackNode
	{
		E value;
		StackNode* below;

		StackNode(E element, StackNode* node) : value(element)
		{
			below = node;
		}
	};

	template<typename E>
	class SimpleStack
	{
	public:
		SimpleStack()
		{
			top = 0;
		}

		void Push(const E& element)
		{
			top = new StackNode<E>(element, top);
		}

		E Pop()
		{
			E element = top->value;
			StackNode<E>* node = top;
			top = top->below;
			delete node;
			return element;
		}

		bool Empty() const
		{
			return top == 0;
		}

		~SimpleStack()
		{
			while(top)
				Pop();
		}

		// nested class
		class Iterator 
		{
		public:
			Iterator(StackNode<E>* node)
			{
				current = node;
			}

			E& operator*() const
			{
				return current->value;
			}

			E* operator->() const
			{
				return &current->value;
			}

			bool operator!=(const Iterator& other) const 
			{
				return current != other.current;
			}

			Iterator& operator++()
			{
				current = current->below;
				return *this;
			}
		private:
			StackNode<E>* current;
		};

		Iterator Begin() const
		{
			return Iterator(top);
		}

		Iterator End() const
		{
			return Iterator(0);
		}

	private:
		StackNode<E>* top;
	};

	template<typename I, typename P>
	int Count(I begin, I end, P check)
	{
		int count = 0;

		for(I i = begin; i != end; ++i)
		{
			if(check(*i))
				count += 1;
		}

		return count;
	}
}

#endif


