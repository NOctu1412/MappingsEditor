using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MappingsEditor {
    public record class MemberData {
        public string? Name { get; init; }
        public string? ObfuscatedName { get; init; }
        public string? Descriptor { get; init; }
        public bool Static { get; init; }

        public MemberData() { }

        public MemberData(string? name, string? obfName, string? desc, bool isStatic) {
            Name = name;
            ObfuscatedName = obfName;
            Descriptor = desc;
            Static = isStatic;
        }
    }

    public class ClassData {
        public string Name { get; set; } = "";
        public string ObfuscatedName { get; set; } = "";
        public List<MemberData> Fields { get; set; } = new();
        public List<MemberData> Methods { get; set; } = new();

        public override string ToString() {
            return Name;
        }

        public static string SerializeClassDataList(List<ClassData> classDataList) {
            var filteredClassDataDict = new Dictionary<string, object>();

            foreach (var classData in classDataList) {
                if (string.IsNullOrEmpty(classData.Name) || string.IsNullOrEmpty(classData.ObfuscatedName)) continue;

                var filteredFields = classData.Fields.FindAll(IsMemberDataValid);
                var filteredMethods = classData.Methods.FindAll(IsMemberDataValid);

                var filteredClassData = new {
                    classData.ObfuscatedName,
                    Fields = filteredFields,
                    Methods = filteredMethods
                };

                filteredClassDataDict[classData.Name] = filteredClassData;
            }

            var options = new JsonSerializerOptions {
                WriteIndented = false,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            return JsonSerializer.Serialize(filteredClassDataDict, options);
        }

        private static bool IsMemberDataValid(MemberData member) {
            return !string.IsNullOrEmpty(member.Name) &&
                   !string.IsNullOrEmpty(member.ObfuscatedName) &&
                   !string.IsNullOrEmpty(member.Descriptor);
        }

        public static List<ClassData> DeserializeClassDataList(string json) {
            var options = new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true
            };

            var classDataDict = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json, options) ?? new Dictionary<string, JsonElement>();
            var classDataList = new List<ClassData>();

            foreach (var kvp in classDataDict) {
                var classData = new ClassData {
                    Name = kvp.Key,
                    ObfuscatedName = kvp.Value.GetProperty("ObfuscatedName").GetString() ?? ""
                };

                classData.Fields = DeserializeMemberDataList(kvp.Value.GetProperty("Fields"));
                classData.Methods = DeserializeMemberDataList(kvp.Value.GetProperty("Methods"));

                classData.Fields = classData.Fields.FindAll(IsMemberDataValid);
                classData.Methods = classData.Methods.FindAll(IsMemberDataValid);

                classDataList.Add(classData);
            }

            return classDataList;
        }

        private static List<MemberData> DeserializeMemberDataList(JsonElement jsonElement) {
            var memberDataList = new List<MemberData>();

            foreach (var item in jsonElement.EnumerateArray()) {
                var memberData = JsonSerializer.Deserialize<MemberData>(item.GetRawText(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (memberData != null) {
                    memberDataList.Add(memberData);
                }
            }

            return memberDataList;
        }
    }
}
