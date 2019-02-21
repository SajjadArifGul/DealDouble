/*
This script was created by Visual Studio on 2/21/2019 at 12:03 AM.
Run this script on (localdb)\MSSQLLocalDB.DealDoubleDB (DESKTOP-4OLGO9A\My Guest) to make it the same as dealddb.mssql.somee.com.dealddb (DealDouble_SQLLogin_1).
This script performs its actions in the following order:
1. Disable foreign-key constraints.
2. Perform DELETE commands. 
3. Perform UPDATE commands.
4. Perform INSERT commands.
5. Re-enable foreign-key constraints.
Please back up your target database before running this script.
*/
SET NUMERIC_ROUNDABORT OFF
GO
SET XACT_ABORT, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
/*Pointer used for text / image updates. This might not be needed, but is declared here just in case*/
DECLARE @pv binary(16)
BEGIN TRANSACTION
ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
ALTER TABLE [dbo].[Categories] DROP CONSTRAINT [FK_dbo.Categories_dbo.Categories_ParentCategoryID]
ALTER TABLE [dbo].[Auctions] DROP CONSTRAINT [FK_dbo.Auctions_dbo.Categories_CategoryID]
ALTER TABLE [dbo].[AuctionPictures] DROP CONSTRAINT [FK_dbo.AuctionPictures_dbo.Pictures_PictureID]
ALTER TABLE [dbo].[AuctionPictures] DROP CONSTRAINT [FK_dbo.AuctionPictures_dbo.Auctions_AuctionID]
ALTER TABLE [dbo].[Bids] DROP CONSTRAINT [FK_dbo.Bids_dbo.Auctions_AuctionID]
ALTER TABLE [dbo].[Bids] DROP CONSTRAINT [FK_dbo.Bids_dbo.AspNetUsers_UserID]
SET IDENTITY_INSERT [dbo].[Pictures] ON
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (1, N'888de21f-afc4-4bbd-9d12-2989c8ccdeee.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (2, N'a922bf07-dbdc-4dfc-a6ba-6d7e3c52b45c.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (3, N'97187433-da93-4e65-a3b6-4857705e4d98.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (4, N'e675f8b5-ee46-4757-9227-e6fc9e97f718.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (5, N'0e3eac5e-72d4-42fd-88c3-96b47211461f.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (6, N'737e2bcb-1afe-46ed-9e2a-d753f26e3541.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (7, N'0b7859e2-e2f7-482a-a70b-f12eafb6db44.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (8, N'3536bdfd-1256-4564-952c-c1533d077f10.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (9, N'826c2aa7-26f0-4f23-83df-759f0e0f7e39.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (10, N'c262f77c-ac04-4044-a293-09e9c328e276.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (11, N'ed982a63-ee9e-4aef-82d2-00e84c644d1a.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (12, N'9c0332c3-1994-4864-9e3b-bd8259853e8f.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (13, N'631c5ff3-0e4b-4286-bd19-7e0e0815a8c8.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (14, N'd1931c03-846a-4e5a-bb45-a44e2906be96.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (15, N'9f6dca9f-e343-4d64-bc13-68108602d233.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (16, N'87ae79d3-854e-4000-ac66-98b19e384b1e.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (17, N'2f4c6820-2ec0-4535-9f55-e06a435ff9b2.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (18, N'ab361953-9777-4c8b-aee2-4b001112da01.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (19, N'b67f6097-baca-436e-ae73-650a8df8a1d1.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (20, N'be152445-e38c-4a47-9f82-d656988217bd.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (21, N'af1bd008-d29a-4dfc-b574-fdca596060c5.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (22, N'8577cfef-b350-4eb5-8bca-43f63f16c427.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (23, N'61b814d0-7a1a-4f91-815f-a2908f95980c.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (24, N'497ff0e9-177c-400f-8359-cd73392e04ac.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (25, N'576fed2d-554e-4ed3-832b-6fac40d3013a.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (26, N'602befae-062e-400c-b015-4a58055947bd.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (27, N'07b14fc9-7d37-44bc-ab98-6755e990160f.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (28, N'1619f983-cfdc-4afd-9cca-a753027d46af.jpg')
INSERT INTO [dbo].[Pictures] ([ID], [URL]) VALUES (29, N'dd168999-0656-44df-99ba-da2f1a8f5b54.jpg')
SET IDENTITY_INSERT [dbo].[Pictures] OFF
SET IDENTITY_INSERT [dbo].[AuctionPictures] ON
INSERT INTO [dbo].[AuctionPictures] ([ID], [AuctionID], [PictureID]) VALUES (1, 1, 1)
INSERT INTO [dbo].[AuctionPictures] ([ID], [AuctionID], [PictureID]) VALUES (2, 1, 2)
INSERT INTO [dbo].[AuctionPictures] ([ID], [AuctionID], [PictureID]) VALUES (3, 1, 3)
INSERT INTO [dbo].[AuctionPictures] ([ID], [AuctionID], [PictureID]) VALUES (4, 1, 4)
INSERT INTO [dbo].[AuctionPictures] ([ID], [AuctionID], [PictureID]) VALUES (5, 2, 5)
INSERT INTO [dbo].[AuctionPictures] ([ID], [AuctionID], [PictureID]) VALUES (6, 2, 6)
INSERT INTO [dbo].[AuctionPictures] ([ID], [AuctionID], [PictureID]) VALUES (7, 2, 7)
INSERT INTO [dbo].[AuctionPictures] ([ID], [AuctionID], [PictureID]) VALUES (8, 3, 8)
INSERT INTO [dbo].[AuctionPictures] ([ID], [AuctionID], [PictureID]) VALUES (9, 3, 9)
INSERT INTO [dbo].[AuctionPictures] ([ID], [AuctionID], [PictureID]) VALUES (10, 3, 10)
INSERT INTO [dbo].[AuctionPictures] ([ID], [AuctionID], [PictureID]) VALUES (11, 3, 11)
INSERT INTO [dbo].[AuctionPictures] ([ID], [AuctionID], [PictureID]) VALUES (12, 4, 12)
INSERT INTO [dbo].[AuctionPictures] ([ID], [AuctionID], [PictureID]) VALUES (13, 4, 13)
INSERT INTO [dbo].[AuctionPictures] ([ID], [AuctionID], [PictureID]) VALUES (14, 4, 14)
INSERT INTO [dbo].[AuctionPictures] ([ID], [AuctionID], [PictureID]) VALUES (15, 4, 15)
INSERT INTO [dbo].[AuctionPictures] ([ID], [AuctionID], [PictureID]) VALUES (16, 5, 16)
INSERT INTO [dbo].[AuctionPictures] ([ID], [AuctionID], [PictureID]) VALUES (17, 5, 17)
INSERT INTO [dbo].[AuctionPictures] ([ID], [AuctionID], [PictureID]) VALUES (18, 5, 18)
INSERT INTO [dbo].[AuctionPictures] ([ID], [AuctionID], [PictureID]) VALUES (28, 6, 22)
INSERT INTO [dbo].[AuctionPictures] ([ID], [AuctionID], [PictureID]) VALUES (29, 6, 23)
INSERT INTO [dbo].[AuctionPictures] ([ID], [AuctionID], [PictureID]) VALUES (30, 6, 24)
INSERT INTO [dbo].[AuctionPictures] ([ID], [AuctionID], [PictureID]) VALUES (31, 6, 25)
INSERT INTO [dbo].[AuctionPictures] ([ID], [AuctionID], [PictureID]) VALUES (32, 6, 26)
INSERT INTO [dbo].[AuctionPictures] ([ID], [AuctionID], [PictureID]) VALUES (33, 7, 27)
INSERT INTO [dbo].[AuctionPictures] ([ID], [AuctionID], [PictureID]) VALUES (34, 7, 28)
INSERT INTO [dbo].[AuctionPictures] ([ID], [AuctionID], [PictureID]) VALUES (35, 7, 29)
SET IDENTITY_INSERT [dbo].[AuctionPictures] OFF
SET IDENTITY_INSERT [dbo].[Auctions] ON
EXEC(N'INSERT INTO [dbo].[Auctions] ([ID], [Title], [Description], [ActualAmount], [StartingTime], [EndingTime], [CategoryID], [Summary]) VALUES (1, N''2019 Mitsubishi Eclipse Cross ES 1.5T S-AWC - Tarmac Black Metallic'', N''<p>Silver Ice Metallic Form Follows Function Every detail of the 2019 Eclipse Cross is crafted for confidence-inspiring driving. The exterior&#39;s sharp, sculpted lines give it a strong stance.</p>

<p>Dynamic design that captivates is the Mitsubishi standard. Mechanical Front-Wheel Drive Gas-Pressurized Shock Absorbers Front And Rear Anti-Roll Bars Electric Power-Assist Speed-Sensing Steering 16.6 Gal. Fuel Tank Single Stainless Steel Exhaust Strut Front Suspension w/Coil Springs Multi-Link Rear Suspension w/Coil Springs 4-Wheel Disc Brakes w/4-Wheel ABS, Front Vented Discs, Brake Assist and Hill Hold Control Exterior Steel Spare Wheel Compact Spare Tire Mounted Inside Under Cargo Clearcoat Paint Body-Colored Front Bumper w/Black Rub Strip/Fascia Accent and Chrome Bumper Insert Body-Colored Rear Bumper w/Black Rub Strip/Fascia Accent Black Bodyside Cladding, Rocker Panel Extensions and Black Wheel Well Trim Chrome Side Windows.</p>

<p>Trim Body-Colored Door Handles Body-Colored Power Heated Side Mirrors w/Manual Folding and Turn Signal Indicator Fixed Rear Window w/Fixed Interval Wiper and Defroster Deep Tinted Glass Variable Intermittent Wipers Composite/Galvanized Steel Panels Lip Spoiler Chrome Grille Liftgate Rear Cargo Access Tailgate/Rear Door Lock Included w/Power Door Locks Auto Off Projector Beam Halogen Daytime Running Headlamps Front Fog Lamps LED Brakelights Interior Front Bucket Seats -inc: 6-way manually adjustable driver&#39;s seat and 4-way manually adjustable passenger&#39;s seat Driver Seat Passenger Seat -inc: Fold Flat 60-40 Folding Bench Front Facing Manual Reclining Fold Forward Seatback Rear Seat w/Manual Fore/Aft Manual Tilt/Telescoping Steering Column Power Rear Windows and Fixed 3rd Row Windows Front Cupholder Rear Cupholder Remote Keyless Entry w/Integrated Key Transmitter, Illuminated Entry, Illuminated Ignition Switch and Panic Button Remote Releases -Inc: Mechanical Fuel Cruise Control w/Steering Wheel Controls Automatic Air Conditioning HVAC -inc: Underseat Ducts Illuminated Glove Box Driver Foot Rest Interior Trim -inc: Metal-Look Instrument Panel Insert and Metal-Look/Piano Black Console Insert Full Cloth Headliner Urethane Gear Shift Knob Fabric Seat Trim Day-Night Rearview Mirror Driver And Passenger Visor Vanity Mirrors Full Floor Console w/Covered Storage and 2 12V DC Power Outlets Front Map Lights Fade-To-Off Interior Lighting Full Carpet Floor Covering -inc: Carpet Front And Rear Floor Mats Carpet Floor Trim Cargo Area Concealed Storage Cargo Space Lights FOB Controls -inc: Trunk/Hatch/Tailgate Driver And Passenger Door Bins Power 1st Row Windows w/Driver 1-Touch Up/Down Delayed Accessory Power Power Door Locks Trip Computer Outside Temp Gauge Digital/Analog Display Seats w/Cloth Back Material Manual Anti-Whiplash Adjustable Front Head Restraints and Manual Adjustable Rear Head Restraints Front Center Armrest and Rear Center Armrest 1 Seatback Storage Pocket Perimeter Alarm 2 12V DC Power Outlets Air Filtration Entertainment Radio: AM/FM 7.0&quot; Touch Panel Display Audio</p>

<p>4 speakers, Bluetooth wireless technology, USB port, digital HD Radio and steering wheel controls Radio w/Seek-Scan, Clock, Speed Compensated Volume Control, Aux Audio Input Jack and Radio Data System Automatic Equalizer Digital Signal Processor Integrated Roof Antenna 1 LCD Monitor In The Front Safety Electronic Stability Control (ESC) ABS And Driveline Traction Control Side Impact Beams Dual Stage Driver And Passenger Seat-Mounted Side Airbags Low Tire Pressure Warning Dual Stage Driver And Passenger Front Airbags Curtain 1st And 2nd Row Airbags Airbag Occupancy Sensor Driver Knee Airbag Rear Child Safety Locks Outboard Front Lap And Shoulder Safety Belts -inc: Rear Center 3 Point, Height Adjusters and Pretensioners Back-Up Camera Please Note: - Images/video show options trim packages that are not included - Customer is responsible for Tax, Title Registration fees upon taking ownership of the vehicle.'', 29000.00, ''20190202 00:00:00.000'', ''20190228 00:00:00.000'', 1, N''Silver Ice Metallic Form Follows Function Every detail of the 2019 Eclipse Cross is crafted for confidence-inspiring driving. The exterior''''s sharp, sculpted lines give it a strong stance.'')')
UPDATE [dbo].[Auctions] SET [Description].WRITE(N' - Previous winners of other car auctions are ineligible to participate in this auction</p>
',NULL,NULL) WHERE [ID]=1
INSERT INTO [dbo].[Auctions] ([ID], [Title], [Description], [ActualAmount], [StartingTime], [EndingTime], [CategoryID], [Summary]) VALUES (2, N'2019 Toyota Tacoma SR - Magnetic Gray Metallic', N'<p>Electronically Controlled automatic Transmission with intelligence (ECT-i) Rear-Wheel Drive (RWD) with Automatic Limited-Slip Differential (Auto LSD) Coil-spring double-wishbone front suspension and stabilizer bar;</p>

<p>leaf spring rear suspension with staggered outboard-mounted gas shock absorbers and stabilizer bar Variable-assist power rack-and-pinion steering Power-assisted ventilated front disc brakes; rear drum brakes with tandem booster and Star Safety System&trade; MPG (City/Highway): 20/23 Exterior: Projector-beam headlights with turn Daytime Running Lights (DRL) Dark gray grille with black surround, color-keyed heated power outside mirrors, color-keyed door handles and rear bumper Fiber-reinforced Sheet-Molded Composite (SMC) inner bed with steel outer panels, storage compartments and rail caps, with easy lower, lockable and removable tailgate Deck rail system with four adjustable tie-down cleats and four fixed cargo bed tie-down points 16-in. styled steel wheels with P245/75R16 tires Two-speed windshield wipers Sliding rear glass w/privacy glass Skid plates: on engine/front suspension Integrated color-keyed tailgate spoiler Interior:</p>

<p>Analog instrumentation with speedometer, tachometer, coolant temperature and fuel gauges; 4.2-in. color Multi-Information Display (MID) with outside temperature, odometer, tripmeters and average fuel economy Air conditioning Three total USB ports:5 one USB media port, two USB charge ports Fabric-trimmed seats; 4-way adjustable driver&#39;s seat with lumbar support; 4-way adjustable front passenger seat Urethane tilt/telescopic steering wheel with audio controls Manual day/night rearview mirror Safety: Toyota Safety Sense&trade; P (TSS-P) &mdash; Pre-Collision System with Pedestrian Detection (PCS w/PD), Lane Departure Alert (LDA) with Sway Warning System (SWS), Automatic High Beams (AHB) and Dynamic Radar Cruise Control (DRCC) Star Safety System&trade; &mdash; includes Vehicle Stability Control (VSC), Traction Control (TRAC), Anti-lock Brake System (ABS) with Electronic Brake-force Distribution (EBD), Brake Assist (BA) and Smart Stop Technology&reg; (SST) Driver and front passenger Advanced Airbag System Driver and front passenger seat-mounted side airbags, driver and front passenger knee airbags, and front and rear</p>

<p>Roll-sensing Side Curtain Airbags (RSCA) Driver and front passenger active headrests 3-point seatbelts for all seating positions; driver-side Emergency Locking Retractor (ELR) and Automatic/Emergency Locking Retractor (ALR/ELR) on all passenger seatbelts LATCH (Lower Anchors and Tethers for CHildren) includes lower anchors for front passenger seat on Access Cab and outboard rear seats on Double Cab Tire Pressure Monitor System (TPMS) Hill Start Assist Control (HAC) Engine immobilizer Please Note: - Images show options trim packages that are not included - Customer is responsible for Tax, Title Registration fees upon taking ownership of the vehicle. - Previous winners of other car auctions are ineligible to participate in this auction</p>
', 30500.00, '20190213 00:00:00.000', '20190228 00:00:00.000', 1, N'Electronically Controlled automatic Transmission with intelligence (ECT-i) Rear-Wheel Drive (RWD) with Automatic Limited-Slip Differential (Auto LSD) Coil-spring double-wishbone front suspension.')
EXEC(N'INSERT INTO [dbo].[Auctions] ([ID], [Title], [Description], [ActualAmount], [StartingTime], [EndingTime], [CategoryID], [Summary]) VALUES (3, N''2019 Hyundai Santa Fe SE - AWD - Symphony Silver'', N''<p>2019 Nissan Sentra SV - Gun Metallic Previous winner: RetArmyVet, 10/9/2018, 2018 Chevrolet Cruze Sedan LS - Automatic - Silver Ice Metallic Previous winner: UncleTan, 10/2/2018, 2018 Ford Focus SE - Shadow Black Take the comfort of your family room on your next adventure. Mechanical Engine Type </p>

<p>Inline 4-cylinder Displacement (liters) 2.4 L Horsepower @ RPM 185 @ 6,000 Torque (lb.-ft. @ RPM) 178 @ 4,000 Compression ratio 11.3:1 Valve train DOHC 16-valve with D-CVVT Fuel system: Gasoline Direct Injection (GDI) Front Wheel Drive (FWD) 8-speed automatic with SHIFTRONIC&reg; Idle Stop Go (ISG) Body type: 5-passenger crossover</p>

<p>Body construction: Unibody, high-strength steel Towing Capacity (lbs) 2,000 Front suspension: MacPherson struts with gas-filled damper and stabilizer bar Rear suspension: Multi-link with gas shock absorber and stabilizer bar Motor-Driven Power Steering (MDPS) Turning diameter, curb-to-curb (ft.) 37.5 17-inch alloy wheels with 235/65 R17 tires Safety Features Adjustable front-seat shoulder belt anchors Front seatbelt pretensioners and load limiters LATCH lower anchor and upper tether anchors Power window lock-out button Anti-lock Braking System (ABS) with 4-wheel disc brakes Electronic Stability Control (ESC) with Traction Control System (TCS) and Brake Assist (BA) Vehicle Stability Management Tire Pressure Monitoring System (TPMS) with individual tire indicator Blind-Spot Collision-Avoidance Assist Rear</p>

<p>Cross-Traffic Collision-Avoidance Assist Forward Collision-Avoidance Assist with Pedestrian Detection Lane Keeping Assist Driver Attention Warning Safe Exit Assist Front crumple zone 2.5-mph bumpers Bodyside reinforcements Electronic shift lock system and ignition key interlock &ndash; electronic type Anti-theft system integrated with remote keyless entry and panic alarm Driver and front passenger advanced airbags (SRS) (2) Driver and front passenger seat-mounted side-impact airbags (SRS) (2) Roof-mounted side-curtain airbags with rollover sensors (SRS) (2) Downhill Brake Control (DBC) (AWD) Hillstart Assist Control (HAC) 4-wheel, 4-channel Anti-lock Braking System (ABS) with Electronic Brake-force Distribution (EBD) and Brake Assist (BA) Exterior Features Projector headlights LED accents LED Daytime Running Lights Roof-mounted Center High-Mount Stop Light Automatic headlights High Beam Assist Bodycolor exterior mirrors</p>

<p>Blind-Spot Collision-Avoidance Assist Chrome accent front grille Bodycolor door handles Solar control front glass Rear privacy glass Acoustic-laminated front glass Front 2-speed/variable intermittent windshield wipers Intermittent rear window wiper/washer (non-variable) Interior Features 6-way adjustable driver seat 2-way power lumbar driver seat 60/40-split fold-flat seats with recline and adjustable head restraints 7-inch display audio system Android Auto&trade; and Apple CarPlay&trade; Dual front/rear 2.1-amp USB outlets (1x power/data 3x power) Rear View Monitor with parking guidance Air conditioning Tilt-and-telescopic steering wheel Steering-wheel-mounted audio, cruise and Bluetooth&reg;controls Smart Cruise</p>

<p>Control with stop/start Monochromatic Multi-Information Display Power windows with safety driver auto-down/up Power door and liftgate locks Remote keyless entry system with alarm and panic Bluetooth&reg;hands-free phone system Please Note: - Images show options trim packages that are not included - Customer is responsible for Tax, Title Registration fees upon taking ownership of the vehicle. - Previous winners of other car auctions are ineligible to participate in this auction</p>
'', 32500.00, ''20190207 00:00:00.000'', ''20190228 00:00:00.000'', 1, N''2019 Nissan Sentra SV - Gun Metallic 2018 Chevrolet Cruze Sedan LS - Automatic - Silver Ice Metallic Ford Focus SE - Shadow Black Take the comfort of your family room on your next adventure.'')')
INSERT INTO [dbo].[Auctions] ([ID], [Title], [Description], [ActualAmount], [StartingTime], [EndingTime], [CategoryID], [Summary]) VALUES (4, N'2019 Kia Niro LX - Aurora Black ', N'<p>Magnetic Gray Previous winner: podewiz, 11/2/2018, 2019 Nissan Sentra SV - Gun Metallic Previous winner: RetArmyVet, 10/9/2018, 2018 Chevrolet Cruze Sedan LS - Automatic - Silver Ice Metallic Previous winner: UncleTan, 10/2/2018, 2018 Ford Focus SE - Shadow Black A Smarter Kind of Crossover Mechanical 1.6L (GDI) 4-cyl Engine w/ 43hp</p>

<p>Electric Motor 1.56 kWh Lithium Ion Polymer Battery 6-Speed Dual Clutch Automatic Transmission Regenerative Braking System Idle Stop and Go System (ISG) 16-inch 5-Spoke Alloy Wheels with Aero Wheel Covers Safety Dual Front Advanced Airbags Driver&#39;s Knee Airbag Dual Front Seat-Mounted Side Airbags Full-Length Side Curtain Airbags Lower Anchors and Tethers for Children (LATCH) Anti-Lock Braking System (ABS) Electronic Stability Control, Hill-Start Assist Ctrl Vehicle Stability Management (VSM) Tire Pressure Monitoring System (TPMS) Interior,</p>

<p>Comfort Convenience Dual-Zone Automatic Climate Control Power Windows, Door Locks Outside Mirrors AM/FM/MP3 w/ 7&quot; Touchscreen Rear Camera Android Auto Apple CarPlay Smartphone Integration Bluetooth&reg; Wireless Technology USB / Auxiliary Input Jack and 12 Volt Outlet Cloth Seat Trim 60/40 Split Folding Rear Seats Push Button Start with Smart Key Steering Wheel Controls (Bluetooth/Audio/Cruise) Supervision Meter Cluster w/ LCD Display Center Console w/ Armrest Storage Bin Luggage Under Floor Tray Exterior Auto-On / Off Projection Headlights LED Positioning Lights Roof Rails, Rear Spoiler, and Rear Privacy Glass LED Rear Combination Lamp Please Note: - Images show options trim packages that are not included - Customer is responsible for Tax, Title Registration fees upon taking ownership of the vehicle. - Previous winners of other car auctions are ineligible to participate in this auction</p>
', 29500.00, '20190307 00:00:00.000', '20190330 00:00:00.000', 1, N'Electric Motor 1.56 kWh Lithium Ion Polymer Battery 6-Speed Dual Clutch Automatic Transmission Regenerative Braking System Idle Stop and Go System (ISG) 16-inch 5-Spoke ')
INSERT INTO [dbo].[Auctions] ([ID], [Title], [Description], [ActualAmount], [StartingTime], [EndingTime], [CategoryID], [Summary]) VALUES (5, N'Apple MacBook Pro 15-inch with Touch Bar 2.2GHz 6-core Intel Core i7, 256GB - Silver - 2018', N'<p>Apple MacBook Pro 15-inch with Touch Bar 2.2GHz 6-core Intel Core i7, 256GB - Silver - 2018 The new MacBook Pro has 6-core Intel Core processors for up to 70 percent faster compute speeds.</p>

<p>A brilliant and colorful Retina display featuring True Tone technology for a more true-to-life viewing experience. And the versatile Touch Bar for more ways to be productive. It&#39;s Apple&#39;s powerful notebook. Pushed even further. Product Features 6-core Intel Core i7 processor Brilliant Retina display with True Tone technology Touch Bar and Touch ID Radeon Pro 555X graphics with 4GB of video memory Ultrafast SSD Intel UHD Graphics 630 Four Thunderbolt 3 (USB-C) ports Up to 10 hours of battery life 802.11ac Wi-Fi Force Touch trackpad Key Specifications Backlit Keyboard: Yes Storage Type: SSD Total Storage Capacity: 256GB Processor Speed (Base): 2.2 gigahertz</p>

<p>Processor Model: Intel 8th Generation Core i7 Battery Life: 10 hours Ports Headphone Jack: Yes Number of Thunderbolt 3 Ports: 4 Display Screen Size: 15.4 inches Screen Resolution: 2880 x 1800 (Retina) Touch Screen: No Display Type: LED Storage Storage Type: SSD Total Storage Capacity: 256GB Memory System Memory (RAM): 16GB Processor Processor Model: Intel 8th Generation Core i7 Processor Speed: 2.2 gigahertz Network Connectivity Bluetooth Enabled: Yes Wi-Fi Ready Power Battery Life: 10 Hours</p>
', 2380.00, '20190215 00:00:00.000', '20190322 00:00:00.000', 2, N'Apple MacBook Pro 15-inch with Touch Bar 2.2GHz 6-core Intel Core i7, 256GB - Silver - 2018 The new MacBook Pro has 6-core Intel Core processors for up to 70 percent faster compute speeds.')
INSERT INTO [dbo].[Auctions] ([ID], [Title], [Description], [ActualAmount], [StartingTime], [EndingTime], [CategoryID], [Summary]) VALUES (6, N'Acer Aspire 3 A315-53-55Y1 15.6-Inch HD i5-8250U 16GB Optane + 4GB 1TB Windows 10', N'<p>Acer Aspire 3 A315-53-55Y1 15.6-Inch HD i5-8250U 16GB Optane + 4GB 1TB Windows 10 Product Features: Intel Core i5 i5-8250U 1.60 GHz Quad-core (4 Core) 4 GB DDR4 SDRAM + 16GB Optane 1 TB Serial ATA 15.6-Inch LCD HD LED 1366 x 768</p>

<p>Intel UHD Graphics 620 DDR4 SDRAM Windows 10 Home Product Specifications: Processor Chipset - Processor Manufacturer: Intel - Processor Type: Core i5 - Processor Generation: 8th Gen - Processor Model: i5-8250U - Processor Speed: 1.60 GHz - Maximum Turbo Speed: 3.40 GHz - Processor Core: Quad-core (4 Core) - Cache: 6 MB - Direct Media Interface: 4 GT/s - 64-bit Processing: Yes - Hyper-Threading: Yes - vPro Technology: No Memory - Standard Memory: 4 GB - Maximum Memory: 12 GB - Memory Technology: DDR4 SDRAM - Memory Card Reader: Yes -</p>

<p>Memory Card Supported: - SD - SDXC - Intel Optane Memory Capacity: 16 GB Storage - Total Hard Drive Capacity: 1 TB - Hard Drive Interface: Serial ATA - Hard Drive RPM: 5400 - Optical Drive Type: No Display Graphics - Screen Size: 15.6&quot; - Display Screen Type: LCD - Aspect Ratio: 16:9 - Screen Mode: HD - Screen Resolution: 1366 x 768 - Backlight Technology: LED - HDCP Supported: Yes - Graphics Controller Manufacturer: Intel - Graphics Controller Model: UHD Graphics 620 - Graphics Memory Technology: DDR4 SDRAM - Graphics Memory Accessibility: Shared - TV Card: No Network Communication - Wireless LAN: Yes - Wireless LAN Standard: IEEE 802.11ac - Ethernet Technology: Gigabit Ethernet - Bluetooth: Yes Built-in Devices - Front Camera/Webcam: Yes - Front Camera/Webcam Resolution: 0.3 Megapixel - Front Camera/Webcam Video Resolution: 640 x 480 - Microphone: Yes - Microphone Type: Digital - Finger Print Reader: No - Speakers: Yes - Number of Speakers: 2 - Sound Mode: Stereo Interfaces/Ports - HDMI: Yes - Total Number of USB Ports: 3 - Number of USB 2.0 Ports: 2 - Number of USB 3.0 Ports: 1 - Network (RJ-45): Yes - Headphone/Microphone Combo Port: Yes Software -</p>

<p>Operating System Platform: Windows - Operating System: Windows 10 Home - Operating System Architecture: 64-bit Input Devices - Keyboard: Yes - Numeric Pad: Yes - Pointing Device Type: TouchPad - TouchPad Features: Multi-touch Gesture - Keyboard Localization: English Battery Information - Number of Cells: 2-cell - Battery Chemistry: Lithium Ion (Li-Ion) - Battery Capacity: 4810 mAh Power Description - Maximum Power Supply Wattage: 65 W Physical Characteristics - Color: Obsidian Black - Height: 0.8&quot; - Width: 15&quot; - Depth: 10.3&quot; - Weight (Approximate): 4.63 lb</p>
', 480.00, '20190214 00:00:00.000', '20190322 00:00:00.000', 2, N'Acer Aspire 3 A315-53-55Y1 15.6-Inch HD i5-8250U 16GB Optane + 4GB 1TB Windows 10 Product Features: Intel Core i5 i5-8250U 1.60 GHz Quad-core (4 Core) 4 GB DDR4 SDRAM')
INSERT INTO [dbo].[Auctions] ([ID], [Title], [Description], [ActualAmount], [StartingTime], [EndingTime], [CategoryID], [Summary]) VALUES (7, N'Verdict. Revival Turntable with Bluetooth Speaker', N'<p>Verdict. Revival Turntable with Bluetooth Speaker It&rsquo;s &ldquo;Throw-Back Thursday&rdquo; every day with the Verdict. Revival Turntable With Bluetooth Speaker. Eclectic, yet utterly functional, the Revival Turntable is a combination of a traditional turntable with a high-power Bluetooth speaker that sets the bar for quality sound everywhere.</p>

<p>The Revival Turntable gives you options for your life that takes retro and makes it work even better with today&rsquo;s technologies. Choose from 3 speeds so you can play your 33&rsquo;s, 45&rsquo;s, and 78&rsquo;s all on the same player. The manual return arm lets you start the music where you like, and you control where the needle ends up. Play your favorite song or two, then move on to the next album. Don&rsquo;t forget about your digital tunes. Play all your favorite music on the Revival Turntable by pairing it with Bluetooth-enabled smartphones, tablets, and other music devices. Pairing the best of the old days with the high-tech of today&rsquo;s functionality, a rechargeable battery lets you enjoy hours of spinning vinyl and digital playback time, and premium speakers give your fresh music selection incredibly precise tones. The best feature, though, is the portability of the Revival Turntable. Just grab the convenient handle, and take your tunes with you anywhere and everywhere. Reflect your taste in all that&rsquo;s good about today&rsquo;s music with the retro style that made old time rock &rsquo;n&rsquo; roll a breakout move back in the day.</p>

<p>Plays records at 3 speeds &ndash; 33, 45, 78RPM Pair your Bluetooth-enabled devices Rechargeable lithium-ion battery Convenient portable handle to take your music everywhere Two secure front metal briefcase clasps Closed Revival Turntable 13.75-in long x 10-in wide x 4.75-in tall USB charging cable (USB power adapter not included) About Verdict. Each grain of sand is unique from the other billions of sand grains on a single beach, but together they make up a stunning background. Verdict. Life is recreating that background for your life with innovative products that resonate with the plea to &ldquo;live and let live,&rdquo; to celebrate our differences that make this life worth living. The Verdict. Life is a treasured story in a book of empty words, but we&rsquo;re more than ideas on a page leading you to a foregone conclusion. Verdict. Life is a journey reimagined through compassion, understanding, and acceptance.</p>

<p>Like water that seeks its own level whether in a cup or in a lake, Verdict. Life can&rsquo;t be defined by a shape or a container. It just is. We made these products for ourselves because we wanted something different, something that spoke to us as human beings, not just faceless consumers. Take a look at our products to understand what we represent. We are a familiar face in a crowd of strangers. Verdict. Life is to be outstanding&mdash;just the way you are.</p>
', 250.00, '20190211 00:00:00.000', '20190221 00:00:00.000', 1, N'Revival Turntable With Bluetooth Speaker. Eclectic, yet utterly functional, the Revival Turntable is a combination of a traditional turntable with a high-power Bluetooth for quality sound everywhere.')
SET IDENTITY_INSERT [dbo].[Auctions] OFF
SET IDENTITY_INSERT [dbo].[Categories] ON
INSERT INTO [dbo].[Categories] ([ID], [Name], [Description], [Summary], [ParentCategoryID]) VALUES (1, N'Vehicles', N'Add Bids on Vehicle Auctions', NULL, NULL)
INSERT INTO [dbo].[Categories] ([ID], [Name], [Description], [Summary], [ParentCategoryID]) VALUES (2, N'Electronics', N'Add Bids on Electronic Item auctions.', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Categories] OFF
ALTER TABLE [dbo].[Categories]
    ADD CONSTRAINT [FK_dbo.Categories_dbo.Categories_ParentCategoryID] FOREIGN KEY ([ParentCategoryID]) REFERENCES [dbo].[Categories] ([ID])
ALTER TABLE [dbo].[Auctions]
    ADD CONSTRAINT [FK_dbo.Auctions_dbo.Categories_CategoryID] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Categories] ([ID]) ON DELETE CASCADE
ALTER TABLE [dbo].[AuctionPictures]
    ADD CONSTRAINT [FK_dbo.AuctionPictures_dbo.Pictures_PictureID] FOREIGN KEY ([PictureID]) REFERENCES [dbo].[Pictures] ([ID]) ON DELETE CASCADE
ALTER TABLE [dbo].[AuctionPictures]
    ADD CONSTRAINT [FK_dbo.AuctionPictures_dbo.Auctions_AuctionID] FOREIGN KEY ([AuctionID]) REFERENCES [dbo].[Auctions] ([ID]) ON DELETE CASCADE
ALTER TABLE [dbo].[Bids]
    ADD CONSTRAINT [FK_dbo.Bids_dbo.Auctions_AuctionID] FOREIGN KEY ([AuctionID]) REFERENCES [dbo].[Auctions] ([ID]) ON DELETE CASCADE
ALTER TABLE [dbo].[Bids]
    ADD CONSTRAINT [FK_dbo.Bids_dbo.AspNetUsers_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[AspNetUsers] ([Id])
COMMIT TRANSACTION
