interface ItemCount {
  itemCount: number;
}

interface itemInfo {
  AttributeType: number;
  DarkAttribute: number;
  EarthAttribute: number;
  Enchant: number;
  FireAttribute: number;
  HolyAttribute: number;
  ItemSlot: number;
  Ls1: number;
  Ls2: number;
  Ls3: number;
  SoulCrystal1: number;
  SoulCrystal2: number;
  SoulCrystal3: number;
  WaterAttribute: number;
  WeaponAttributeStat: number;
  WindAttribute: number;
}

interface TraderInfo {
  ItemId: number;
  ObjectId: number;
  Price: number;
  Quantity: number;
  StoreItemType: number;
  StoreType: number;
  TypeOfModification: number;
  VendorId: number;
  VendorName: string;
  x: number;
  y: number;
  z: number;
  ItemName: string;
}

interface VisualInfo {
  VisualId: number;
  VisualIdName: string;
}

/*export interface IPrivateShop {
  id: string;
  realName?: string;
  itemCount: ItemCount;
  itemInfo: itemInfo;
  traderInfo: TraderInfo;
  visualInfo: VisualInfo;
  isActive: boolean;
  updatedAt: Date;
  createdAt: Date;
}*/


export interface IPrivateShop {
  itemCount: number;
  vendorName: string;
  vendorId: number;
  storeType: number;
  price: number;
  x: number;
  y: number;
  z: number;
  typeOfModification: number;
  objectId: number;
  itemId: number;
  quantity: number;
  storeItemType: number;
  itemSlot: number;
  enchant: number;
  ls1: number;
  ls2: number;
  ls3: number;
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
  visualId: number;
  itemName: string;
  id: number;
}
