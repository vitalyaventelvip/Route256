fun main() {
    repeat(readln().toInt()) {
        val nums = readln().split(" ").map { it.toInt() }
        println(nums[0] + nums[1])
    }
}
