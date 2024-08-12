using Murmur;
using System.Buffers.Binary;
using System.Text;

namespace TotkMurmurHashTool.Helpers;

public class YamlResultHelper
{
    private const string GDL_DEFAULT_ENTRY = "DefaultValue: false, Hash: !u {0}, ResetTypeValue: 16, SaveFileIndex: 0";
    private const string GDL_ENTRY = "Hash: !u {0}, Value: !u {1}";

    private static readonly Murmur32 _murmur32 = MurmurHash.Create32();

    public static string CreateGdlResult(string[] actorNames, string[] constants)
    {
        StringBuilder sb = new("""
            # bool

            """);

        foreach (string actorName in actorNames) {
            foreach (string constant in constants) {
                string hash = Hash($"{constant}.{actorName}");
                sb.AppendLine($$"""
                      - { {{string.Format(GDL_DEFAULT_ENTRY, hash)}} }
                    """);
            }
        }

        foreach (string constant in constants) {
            sb.AppendLine($"\n# {Hash(constant)} ({constant})");
            foreach (string actorName in actorNames) {
                string actorNameHash = Hash(actorName);
                string mixHash = Hash($"{constant}.{actorName}");

                sb.AppendLine($$"""
                        - { {{string.Format(GDL_ENTRY, actorNameHash, mixHash)}} }
                    """);
            }
        }

        return sb.ToString();
    }

    private static string Hash(string input)
    {
        return $"""
            0x{BinaryPrimitives.ReadUInt32LittleEndian(_murmur32.ComputeHash(Encoding.UTF8.GetBytes(input))):x8}
            """;
    }
}
