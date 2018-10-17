package main

import (
	"fmt"
	"math"
)

// Newton-Raphson method (simple)
func Sqrt(x float64) float64 {
	prev := 1.0
	z := 1.0
	i := 0
	init := false
	for {
		i++
		prev = z
		z -= (z*z - x) / (2 * z)
		if z == prev || (init && math.Abs(prev) < math.Abs(z+0.00000000001)) {
			break
		}
		init = true
	}
	fmt.Println("input:", int64(x))
	fmt.Println("count:", i)
	return z
}

func main() {
	input := float64(67000000000)
	result := Sqrt(input)
	fmt.Println("try:", result)
	fmt.Println("math:", math.Sqrt(input))
}

// input: 67000000000
// count: 24
// try: 258843.5821108957
// math: 258843.5821108957
