# 다대다 테이블 조회 연구

## 결과

* 10000건을 기준 으로 조회 테스트를 진행
  * 최적 쿼리 N:M 조회시 083~63ms
  * EF Core 조회시 076ms
  * 1:1 조회시 046ms
  * 뷰를 통해 N:M 을 1:1 테이블로 변환시 200ms

## 결론

* 채널이 8개라 조회를 위해서 8개의 라인이 더 생기는 것으로 가정 하면, 데이터 적인 입장에서 1:1 조회를 위해 별도의 테이블을 생성하는것이 크게 의미 없을수도 있다. 

## 사용 된 기술

* Clean 아키텍처
* CQRS
* AutoMapper(lib)
* MediatR(lib)

## 핵심 관점

* Dto를 AutoMapper를 통해 쉽게 Parameter Class화 하였다.
* CQRS 를 구현하여 