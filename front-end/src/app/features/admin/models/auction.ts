export interface Auction {
  id: string;
  isActive: boolean;
  createdAt: string;
  updatedAt: string;

  // ItemMetaData
  commissionId: number;
  pricePerUnit: number;
  commissionItemType: number;
  durationInDays: number;
  epochSecondEndTime: number;
  sellerName: string;
  typeOfModification: number;

  // ItemInfo
  objectId: number;
  itemId: number;
  count: number;
  storeItemType: number;
  itemSlot: number;
  enchant: number;
  attributeType: number;
  weaponAttributeStat: number;
  waterAttribute: number;
  fireAttribute: number;
  earthAttribute: number;
  windAttribute: number;
  darkAttribute: number;
  holyAttribute: number;
  soulCrystal1: number;
  soulCrystal2: number;
  soulCrystal3: number;
  itemName: string;

  // VisualInfo
  visualId: number;
  visualIdName: string;
}
