-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th10 12, 2021 lúc 09:45 AM
-- Phiên bản máy phục vụ: 10.4.21-MariaDB
-- Phiên bản PHP: 7.3.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `greenhub`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `orders`
--

CREATE TABLE `orders` (
  `id_cus` int(11) NOT NULL,
  `id_prod` int(11) NOT NULL,
  `soluong` int(11) NOT NULL,
  `cus_name` varchar(30) NOT NULL,
  `phone_num` varchar(100) NOT NULL,
  `addr` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `orders`
--

INSERT INTO `orders` (`id_cus`, `id_prod`, `soluong`, `cus_name`, `phone_num`, `addr`) VALUES
(1, 1, 2, 'Le Van B', '0337222647', 'HCM'),
(2, 1, 1, 'Le Van B', '0337222647', 'HCM'),
(3, 5, 1, 'Le Van B', '0337222647', 'HCM'),
(4, 2, 1, 'aaa', 'aaa', 'vvv');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `products`
--

CREATE TABLE `products` (
  `id` int(11) NOT NULL,
  `name` varchar(200) NOT NULL,
  `price` float NOT NULL,
  `description` varchar(1000) NOT NULL,
  `img` varchar(250) DEFAULT NULL,
  `soluong` int(11) DEFAULT NULL,
  `nhacungcap` varchar(50) DEFAULT NULL,
  `loai` varchar(50) DEFAULT NULL,
  `ngaysanxuat` date DEFAULT NULL,
  `hansudung` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `products`
--

INSERT INTO `products` (`id`, `name`, `price`, `description`, `img`, `soluong`, `nhacungcap`, `loai`, `ngaysanxuat`, `hansudung`) VALUES
(1, 'Cam tươi', 20000, '', 'image\\product-1.png', 100, 'Doanh nghiệp A', 'TH', '2021-11-11', '2021-11-13'),
(2, 'Củ hành', 10000, '', 'image\\product-2.png', 100, 'Doanh nghiệp E', 'RC', '2021-11-13', '2021-11-15'),
(5, 'Thịt lợn', 100000, '', 'image\\product-3.png', 100, 'Doanh nghiệp D', 'TH', '2021-11-15', '2021-11-17'),
(6, 'Khoai tây', 10000, '', 'image\\product-5.png', 100, 'Doanh nghiệp A', 'RC', '2021-11-17', '2021-11-19'),
(7, 'Cà rốt', 25000, '', 'image\\product-7.png', 100, 'Doanh nghiệp C', 'RC', '2021-11-19', '2021-11-21'),
(8, 'Bơ', 40000, '', 'image\\product-6.png', 100, 'Doanh nghiệp B', 'RC', '2021-11-21', '2021-11-23'),
(9, 'Chanh', 10000, '', 'image\\product-8.png', 200, 'Doanh nghiệp B', 'RC', '2021-11-23', '0000-00-00'),
(10, 'Bắp cải', 15000, '', 'image\\product-4.png', 100, 'Doanh nghiệp A', 'RC', '2021-11-25', '2021-11-27'),
(11, 'Thịt bò', 150000, 'Thịt bò hảo hạng, tươi ngon. Xuất xứ trung quốc nên thịt dở và không đáng mua', 'image\\beef.png', 30, 'Doanh nghiep A', 'TH', '2021-11-27', '2021-11-29');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `user`
--

CREATE TABLE `user` (
  `email` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `name` varchar(100) NOT NULL,
  `phone` varchar(10) DEFAULT NULL,
  `address` varchar(100) DEFAULT NULL,
  `cmnd` varchar(9) DEFAULT NULL,
  `birth` varchar(8) DEFAULT NULL,
  `sex` varchar(5) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`id_cus`);

--
-- Chỉ mục cho bảng `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`email`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `orders`
--
ALTER TABLE `orders`
  MODIFY `id_cus` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT cho bảng `products`
--
ALTER TABLE `products`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
