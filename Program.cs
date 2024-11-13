//*****************************************************************************
//** 2563. Count the Number of Fair Pairs    leetcode                        **
//*****************************************************************************

int compare(const void* a, const void* b) {
    return (*(int*)a - *(int*)b);
}

int* lower_bound(int* start, int* end, int value) {
    int* left = start;
    int* right = end;
    
    while (left < right) {
        int* mid = left + (right - left) / 2;
        if (*mid < value) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    return left;
}

long long countFairPairs(int* nums, int numsSize, int lower, int upper) {
    long long ans = 0;
    qsort(nums, numsSize, sizeof(int), compare);
    
    for (int i = 0; i < numsSize; ++i) {
        int* j = lower_bound(nums + i + 1, nums + numsSize, lower - nums[i]);
        int* k = lower_bound(nums + i + 1, nums + numsSize, upper - nums[i] + 1);
        ans += k - j;
    }
    
    return ans;
}