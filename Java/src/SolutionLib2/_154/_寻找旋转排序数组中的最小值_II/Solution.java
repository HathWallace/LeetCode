package SolutionLib2._154._寻找旋转排序数组中的最小值_II;

class Solution {
    public int findMin(int[] nums) {
        int index=findMin(nums,0,nums.length-1);
        return nums[index];
    }

    private int findMin(int[] nums,int left,int right){
        if(right-left<2) return nums[left]<nums[right]?left:right;
        if(nums[left]<nums[right]) return left;
        int mid=left+(right-left)/2;
        if(nums[left]>nums[mid]) return findMin(nums,left+1,mid);
        if(nums[mid]>nums[right]) return findMin(nums,mid+1,right);
        int leftFind=findMin(nums,left+1,mid);
        int rightFind=findMin(nums,mid+1,right);
        return nums[leftFind]<nums[rightFind]?leftFind:rightFind;
    }
}