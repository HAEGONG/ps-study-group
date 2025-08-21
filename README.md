# 🚀 C\# 알고리즘 스터디 규칙

원활한 스터디 진행과 코드 관리를 위해 아래 규칙을 꼭 지켜주세요\!

### 1\. 폴더 구조 (Folder Structure)

  - 문제는 **플랫폼 폴더** 아래에 `P`와 **문제 번호**를 조합한 폴더를 생성하여 관리합니다.
  - **예시:**
    ```
    Baekjoon/
    ├── P1000/
    │   ├── Eunji.cs
    │   └── Cheolsu.cs
    └── P1001/
        └── Minjun.cs
    ```

### 2\. 소스 코드 규칙 (Source Code Rules)

  - **파일명:** 각자의 소스 파일은 `영문이름.cs` 형식으로 생성합니다.

  - **클래스명:** 파일명과 동일한 `public class 영문이름` 형식으로 작성하여 클래스 간 충돌을 방지합니다.

  - **네임스페이스:** **`플랫폼.P문제번호`** 형식으로, 실제 폴더 경로와 정확히 일치시킵니다.

  - **예시 코드 (`Baekjoon/P1000/Gildong.cs`):**

    ```csharp
    namespace Baekjoon.P1000
    {
        public class Gildong
        {
            public static void Main(string[] args)
            {
                // 문제 풀이 코드
            }
        }
    }
    ```

### 3\. 코드 리뷰 (Code Review)

  - 다른 사람의 코드를 자유롭게 읽어보고 궁금한 점이나 더 좋은 아이디어가 있다면 GitHub의 **댓글** 기능을 적극적으로 활용해 의견을 나눠주세요. 건강한 코드 리뷰 문화는 모두의 성장에 기여합니다\!
