# Allgemeines

DeepCopy klappt nicht mit HashSets, da die internen Felder (_bucket etc.) wohl nicht sauber kopiert werden können.
Siehe:
- https://github.com/DrMueller/DeepCopyEfCoreTest
- Diskussion: https://github.com/dotnet/efcore/issues/32904#event-11625333554