package com.elfak.scrumpro.dto;

import lombok.*;

@Builder
@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
public class CompanyUserDTO {

    private Long companyId;
    private Long userId;
}
