package com.elfak.scrumpro.shared.dto;

import lombok.Builder;
import lombok.Getter;
import lombok.Setter;

@Builder
@Getter
@Setter
public class UserDTO {

    private Long id;

    private String username;
}
