class Solution {
    public int removeElement(int[] nums, int val) {
        int[] c=new int[nums.length];
        int cof_c = 0, cof_n=0, counter=0;
        for (int i=0;i<nums.length;i++){
            if(nums[i]==val){
                c[cof_c]=i;
                cof_c++;
                nums[i]=0;
                counter++;
            }
            else {
                if ((cof_c != 0) && (cof_n<=cof_c)) {
                    nums[c[cof_n]]=nums[i];
                    cof_n++;
                    c[cof_c]=i;
                    cof_c++;
                    nums[i]=0;
                }
            }
        }
        int s=nums.length-counter;
        return s;
    }
}