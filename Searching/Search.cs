namespace Algorithms.Searching
{
    public static class Search
    {

        /// <summary>
        /// Binary Search
        /// Look for an element x in a sorted array by first comparing x to the midpoint in the array
        /// If x is less than the midpoint, then we search the left half of the array
        /// If x is greater than the midpoint, then we search the right half of the array
        /// Repeat this process until we find x
        /// </summary>
        /// <param name="a">Assumes this is a sorted array</param>
        /// <param name="x">The element position we're looking for</param>
        /// <returns></returns>
        public static int BinarySearch(int[] a, int x){
            int low = 0;
            int high = a.Length - 1;
            int mid;

            while (low <= high){
                mid = (low + high) /2;
                if(a[mid] < x){//the element is larger than the midpoint, it must be present in the right subarray
                    low = mid + 1;
                }else if(a[mid] > x){//the element is smaller than the midpoint, it must be present in the left subarray
                    high = mid -1;

                }else{
                    return mid;//the position of the element we're looking
                }
            }
            return -1;//the element is not present in the array

        }

        /// <summary>
        /// Binary Search Recursive
        /// Recusively look for an element x in a sorted array by first comparing x to the midpoint in the array
        /// If x is less than the midpoint, then we search the left half of the array
        /// If x is greater than the midpoint, then we search the right half of the array
        /// Repeat this process until we find x
        /// </summary>
        /// <param name="a">Assumes this is a sorted array</param>
        /// <param name="x">The element positoin we're looking for</param>
        /// <param name="low">Starting left position</param>
        /// <param name="high">Starting right position</param>
        /// <returns></returns>
        public static int BinarySearchRecursive(int[] a, int x, int low, int high){
            if(low > high) return -1;//the element is not present in the array

            int mid = (low + high) /2;
            if(a[mid] < x){//the element is larger than the midpoint, it must be present in the right subarray
                return BinarySearchRecursive(a, x, mid + 1, high);
            } else if(a[mid] > x){//the element is smaller than the midpoint, it must be present in the left subarray
                return BinarySearchRecursive(a, x, low, mid - 1);
            }else{
                return mid;//the position of the element we're looking
            }
        }
    }
}