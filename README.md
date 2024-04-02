# Endpoint
Work associated with C# on STM32MP boards

This repository explores the use of C# to manipulate peripheral registers on [GHI's Endpoint 'Domino'](https://www.ghielectronics.com/endpoint/) board. The approach used is to encapsulate registers with a struct and refer to that using the C# `ref` feature. Each register is represented by a contained struct that contains a single field and a peripheral class contains a member for each distinct register. The register structs are defined within a `partial` struct for the peripheral and the peripheral class has an auto generated part.

The auto generated part defines a property for each register sub field making the abstraction very close to the technical documentation for the registers. The auto generated struct is created from a textual defintion of the register and its sub fields, here's an example used to create the TimerGeneral partial class file (in the 'Generated' sub folder):

```
cr1(0x00):     cen(0,1)bool; udis(1,1)bool; urs(2,1)bool; opm(3,1)bool; dir(4,1)bool; cms(6,2)CenterMode; arpe(7,1)bool; ckd(9,2)uint; uifremap(11,1)bool;
cr2(0x4):      ccds(3,1)bool; mms(6,3)MasterMode; ti1s(7,1)bool;
sr(0x10):      uif(0,1)bool; cc1if(1,1)bool; cc2if(2,1)bool; cc3if(3,1)bool; cc4if(4,1)bool; tif(6,1)bool; cc1of(9,1)bool; cc2of(10,1)bool; cc3of(11,1)bool; cc4of(12,1)bool;
ccmr1(0x18):   cc1s(1,2)CC1SMode; oc1fe(2,1)bool; oc1pe(3,1)bool; oc1m(16,1, 6,3)OCMode; oc1ce(7,1)bool; cc2s(9,2)CC2SMode; oc2fe(10,1)bool; oc2pe(11,1)bool; oc2m(24,1,14,3)OCMode; oc2ce(15,1)bool;
cnt_nre(0x24): this(32,1)bool;
cnt_rem(0x24): this(31,1)bool; uifcpy(31,1)bool;
arr(0x2C):     this(31,1)bool;
psc(0x28):     value(15,16)uint;
ccer(0x20):    cc1e(0,1)bool; cc1p(1,1)bool; cc1np(3,1)bool; cc2e(4,1)bool; cc2p(5,1)bool; cc2np(7,1)bool; cc3e(8,1)bool; cc3p(9,1)bool; cc3np(11,1)bool; cc4e(12,1)bool; cc4p(13,1)bool; cc4np(15,1) bool;
ccr1(0x34):    ccr(31,32)uint;
```
This simple grammar (which is a regular expression grammar) can represent any kind of register and makes it very easy to add register definitions without needing to write any of the intricate boolean expressions for AND and OR and so on. The auto generated struct also includes safety checks that prevent calling code from accidentally setting reserved bits and so on.

The generator logic is part of the class library and will in due course, be managed by a Visual Studio based generator.


