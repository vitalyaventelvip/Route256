import Foundation

let testCaseCount = Int(readLine()!)!
for _ in 0..<testCaseCount {
    let nums = readLine()!.components(separatedBy: " ")
    let x = Int(nums[0])
    let y = Int(nums[1])
    print(x! + y!)
}
