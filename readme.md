# Performance Tips

## If Else Internals

i == 1 is rare while it returns i + 1 most of the time. The instruction jumps and it takes time.

```csharp
if (i == 1)
{
	return -1;
}

return i + 1;
```

Changed to below so the instruction does not need to jump most of the time.

```csharp
if (i != 1)
{
	return i + 1;
}

return -1;
```


|                Method |     Mean |     Error |    StdDev |
|---------------------- |---------:|----------:|----------:|
| NormalInstructionJump | 3.568 ms | 0.0194 ms | 0.0182 ms |
|     NoInstructionJump | 3.437 ms | 0.0485 ms | 0.0430 ms |


## [sharplab](https://sharplab.io)

Convert to JIT Asm

```
C.C1(Int32)
    L0000: cmp edx, 1
    L0003: jne short L000b
    L0005: mov eax, 0xffffffff
    L000a: ret
    L000b: lea eax, [edx+1]
    L000e: ret

C.C2(Int32)
    L0000: cmp edx, 1
    L0003: je short L0009
    L0005: lea eax, [edx+1]
    L0008: ret
    L0009: mov eax, 0xffffffff
    L000e: ret
```