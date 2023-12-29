## Adjust SDK를 이용한 MoPub 광고 매출 트래킹

[Adjust Unity SDK README][unity-readme]

[MoPub Unity 문서][mopub-docs]

이 기능에 필요한 최소 SDK 버전:

- **Adjust SDK v4.18.0**
- **MoPub SDK v5.7.0**

MoPub SDK `OnImpressionTrackedEvent` 콜백 메서드 구현 중에 다음과 같이 `trackAdRevenue` Adjust SDK 메서드를 호출하세요.

```csharp
private void OnImpressionTrackedEvent(string adUnitId, MoPub.ImpressionData impressionData) {
    // Pass impression data JSON to Adjust SDK.
    Adjust.trackAdRevenue(AdjustConfig.AdjustAdRevenueSourceMopub, impressionData.JsonRepresentation);
}
```

MoPub을 이용한 광고 매출 트래킹에 관해 질문이 있는 경우 담당 계정 관리자에게 문의하거나 support@adjust.com에 이메일을 보내 주시기 바랍니다.

[mopub-docs]:        https://developers.mopub.com/publishers/android/impression-data/
[unity-readme]:    ../../korean/README.md
