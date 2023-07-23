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


